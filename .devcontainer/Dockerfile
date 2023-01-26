FROM mcr.microsoft.com/devcontainers/dotnet:0-7.0

# update root certificates
RUN apt-get update && apt-get install -y --no-install-recommends \
        ca-certificates\
 && rm -rf /var/lib/apt/lists/*

# Include the Cisco Umbrella PKI Root
RUN wget -qO /usr/local/share/ca-certificates/Cisco_Umbrella_Root_CA.crt https://www.cisco.com/security/pki/certs/ciscoumbrellaroot.pem \
 && update-ca-certificates