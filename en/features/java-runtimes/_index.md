---
title: Choose a Java runtime
description: Follow the Java library's runtime and deployment requirements.
type: docs
url: /features/java-runtimes/
weight: 1610
feature_id: java-runtimes
feature_group: runtime
translationKey: slides-feature-java-runtimes
feature_catalogue_version: 3
feature_guides:
- /slides/java/system-requirements/
---

## **Overview**

Choose a Java environment using the library's published system requirements. Add the required library package and dependencies to your application, then use the Java examples for presentation processing. Runtime guidance belongs to the Java binding rather than to the presentation file format.

## **Usage guidance**

Select the Java artifact and dependencies described in the [system requirements](/slides/java/system-requirements/). Check the runtime used by the deployed process, which can differ from the Java command selected in a development shell. The [Java API example](/slides/features/java-api/) demonstrates presentation creation; one successful runtime run does not establish a compatibility table for other releases.

## **FAQ**

### **Is there a published compatibility table for every Java LTS release?**

The guidance publishes a minimum Java level rather than a complete per-LTS test matrix. Do not infer a separate tested ceiling from the package name.

### **How can I check which Java runtime my application actually selected?**

Check the executable or service configuration that launches the application and its reported Java version. On machines with several JDKs, changing a shell's PATH does not necessarily change an existing service's runtime.

### **Where should I check dependencies for a particular Java deployment?**

Start with the library's system requirements and installation guide for the selected artifact. Check its operating-system dependencies, font availability and classpath in the actual deployment. Do not infer a tested maximum Java version from an artifact filename.

## **Guides**

- [System Requirements (Java)](/slides/java/system-requirements/)

Related feature: [Use Slides from Java](/slides/features/java-api/).
