---
title: Run Slides in Docker containers
description: Run presentation processing in a Docker container.
type: docs
url: /features/docker/
weight: 330
feature_id: docker
feature_group: deployment
translationKey: slides-feature-docker
feature_catalogue_version: 3
feature_guides:
- /slides/net/how-to-run-aspose-slides-in-docker/
---

## **Overview**

Package the Slides library with your application in a container. Include its runtime dependencies and the fonts used by your presentations, then give the application access to its inputs, outputs and any temporary storage. The documentation includes container setup guidance for library bindings.

## **Usage example**

This PowerShell example runs the **C# / .NET container application** built as *hello-slides* in the [Docker guide](/slides/net/how-to-run-aspose-slides-in-docker/). Complete that guide's image build first; the command below does not build the application. Use a directory without an existing *output* folder and an unused container name. The application creates a one-slide greeting, saves PPTX and PDF files, and stops. The commands copy *hello.pptx* and *hello.pdf* to *output* on the host, then remove the stopped container. No input presentation is required.

```powershell
docker run --name slides-feature-example hello-slides
docker cp slides-feature-example:/app/output ./output
docker rm slides-feature-example
```

## **FAQ**

### **Does the library include a ready-made Slides container image?**

Build your application image with the dependencies for the package you use. The container guide is a starting point for that setup.

### **Which fonts should I include in the container?**

Include the fonts used by your presentations, or deliberately chosen substitutes that cover the needed characters. Minimal runtime images may contain no fonts. Install or load the required fonts and check the rendered output under the same container configuration used in production.

### **Where should the container write temporary and output files?**

Use writable locations for both temporary work and output. A non-root container user needs permission to write there. Copy results from the stopped container as above, or mount a host directory with suitable permissions. Keep persistent results outside the container layer if the container will be removed.

## **Guides**

- [Run Aspose.Slides for .NET in Docker](/slides/net/how-to-run-aspose-slides-in-docker/)

Related feature: [Load fonts from a folder](/slides/features/custom-fonts/).

## Runnable .NET examples

- [Run a Converter in Docker](/slides/net/examples/application-integration/docker/)
