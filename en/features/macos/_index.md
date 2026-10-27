---
title: Run Slides on macOS
description: Use the Slides library in supported macOS application environments.
type: docs
url: /features/macos/
weight: 1630
feature_id: macos
feature_group: runtime
translationKey: slides-feature-macos
feature_catalogue_version: 3
feature_guides:
- /slides/net/system-requirements/
---

## **Overview**

Set up the library and its runtime dependencies on macOS for presentation development or processing. Follow the system requirements for the selected binding and package, including architecture and font requirements. Use the same presentation workflows described in that binding's guides.

## **FAQ**

### **Should I choose requirements by operating system alone?**

Choose by both the operating system and the library binding. The required runtime and native dependencies depend on the package you use.

### **Should the application and its native libraries use the same processor architecture?**

Yes. Match the process architecture to the native graphics library, including when an application runs through an architecture translation layer. Check the selected package rather than assuming the machine model determines the process architecture.

### **How do I provide additional fonts to a macOS application?**

Install the fonts for the service account or load a local application font folder before opening presentations. Verify the required glyphs and rendered layout in that macOS environment.

## **Guides**

- [System Requirements (.NET)](/slides/net/system-requirements/)

Related feature: [Load fonts from a folder](/slides/features/custom-fonts/).
