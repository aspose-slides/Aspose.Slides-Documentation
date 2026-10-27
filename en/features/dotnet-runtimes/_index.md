---
title: Choose a .NET runtime
description: Choose the Slides package and target suitable for your .NET runtime.
type: docs
url: /features/dotnet-runtimes/
weight: 1600
feature_id: dotnet-runtimes
feature_group: runtime
translationKey: slides-feature-dotnet-runtimes
feature_catalogue_version: 3
feature_guides:
- /slides/net/system-requirements/
- /slides/net/net6/
---

## **Overview**

Use the .NET installation and system-requirements guidance to select the library build for your application. Package targets and cross-platform builds have different dependency requirements. Keep that choice aligned with the runtime and operating system used in deployment.

## **Choose the deployment setup**

Start with the application's target framework and deployment operating system, then select the corresponding package and native dependencies. Test rendering on that target with its actual fonts. A successful run on one runtime does not establish compatibility with other operating systems or architectures. For a runnable conversion example, see [Export presentations to PDF](/slides/features/pdf-export/).

## **FAQ**

### **Should every .NET application use the same package setup?**

Choose the build and dependencies for its environment. Cross-platform rendering requirements differ from a Windows-only application.

### **How can I check which .NET runtime my deployed process is using?**

Check the runtime reported by the running process in your application diagnostics, together with the target framework and deployed runtime configuration. The build machine's SDK version and the host's installed-runtime list do not establish which runtime that process selected. Check the deployed environment rather than relying only on a successful development build.

### **Which native dependencies matter for cross-platform rendering?**

The cross-platform package needs fontconfig on Linux and the native runtime required by its platform build. The standard package has different graphics requirements, including libgdiplus and the documented Unix support setting on Linux. Both need suitable fonts. Use the [system requirements](/slides/net/system-requirements/) and [package guidance](/slides/net/net6/) for the exact target.

## **Guides**

- [System Requirements (.NET)](/slides/net/system-requirements/)
- [Cross-Platform Package for .NET 6 and Later](/slides/net/net6/)

Related feature: [Use Slides from .NET](/slides/features/dotnet-api/).
