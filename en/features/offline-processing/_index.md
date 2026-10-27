---
title: Process presentations without internet access
description: Create, edit and render local presentations without an internet connection.
type: docs
url: /features/offline-processing/
weight: 340
feature_id: offline-processing
feature_group: deployment
translationKey: slides-feature-offline-processing
feature_catalogue_version: 3
feature_guides:
- /slides/net/security/
---

## **Overview**

Run ordinary presentation processing with local files, streams and fonts on a machine without outbound network access. Your application controls where the inputs and results are stored. Prepare the library and its dependencies before moving the application into an isolated environment.

## **Usage example**

This PowerShell example runs the C# / .NET application already built as hello-slides in the [Docker guide](/slides/net/how-to-run-aspose-slides-in-docker/). Build and store that image while connected, including its runtime dependencies and fonts; these commands do not build or download it. Use an unused container name and a directory without offline-output. The application creates a greeting presentation and PDF with container networking disabled. The inspection command prints none. The results are copied to offline-output before removing the stopped container. No input presentation, AI endpoint or network license is used in this evaluation example; deploy your appropriate file-based license separately when required.

```powershell
docker run --name slides-offline-example --network none hello-slides
docker inspect slides-offline-example --format '{{.HostConfig.NetworkMode}}'
docker cp slides-offline-example:/app/output ./offline-output
docker rm slides-offline-example
```

## **FAQ**

### **Do AI methods also work without a model connection?**

AI methods need their configured model endpoint. Offline document processing and access to an AI model are separate requirements.

### **Which assets should I install before disconnecting a machine?**

Prepare the chosen library and runtime packages, native dependencies, fonts, input assets and any appropriate file-based license. Optional AI workflows separately require their configured model endpoint.

### **Can I supply fonts from a local application folder?**

Yes. Load a local font folder during application startup, or include the fonts in the prepared runtime image. The files must already be available and readable in the disconnected environment.

## **Guides**

- [Security (.NET)](/slides/net/security/)

Related feature: [Install and license Slides on an isolated network](/slides/features/air-gapped-installation/).
