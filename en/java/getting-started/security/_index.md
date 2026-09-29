---
title: Security
type: docs
weight: 160
url: /java/security/
keywords:
- security
- dependencies
- third-party components
- Maven
- JAR signature
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Review how Aspose.Slides for Java processes presentations, what it adds to your project's dependencies, how to verify the JAR file, and which third-party components it includes."
---

## **Introduction**

This article collects the information that a security review of an application that uses Aspose.Slides for Java usually needs: how the library processes presentations, what it adds to the dependencies of your project, how to check that the JAR file comes from Aspose, and which third-party components the JAR file contains.

## **Security in Aspose.Slides**

Aspose applies best practices when developing its products.

* Aspose.Slides for Java is used to create, modify, and convert presentations. It does not run scripts in presentations. Aspose.Slides parses the presentation structure and lets your code work with the object model.
* Aspose.Slides functions as a library that parses and interprets documents without executing remote code. All Aspose products run on your machines. They do not transmit any data to Aspose. The only exception is [metered licensing](/slides/java/metered-licensing/): if you use it, only your API usage information is processed.
* Aspose components run in the same user context as regular applications. Therefore, Aspose components do not pose a risk to vital system resources. Furthermore, when an Aspose component opens a document, macros are not run automatically.

## **Maven Dependencies**

The Maven artifact of Aspose.Slides for Java, `com.aspose:aspose-slides`, declares no dependencies: its POM file contains only the artifact's own coordinates. When you add it to a project, Maven adds this one JAR file and nothing else. To list every artifact that your project resolves, including transitive dependencies, run this command in the project folder:

```bash
mvn dependency:tree
```

In the project from [Installation](/slides/java/installation/), the output lists Aspose.Slides as the only dependency:

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **Verify the JAR File**

Aspose signs the JAR file. To check the signature, run the `jarsigner` tool from the JDK in the folder that contains the JAR file:

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

The command prints `jar verified.` when the signature is valid and no entry has changed since the file was signed. This message does not name the signer. To confirm that Aspose signed the file, add the `-verbose` and `-certs` options and check that the signer's certificate is issued to `CN=ASPOSE PTY LTD`. When Maven downloads the JAR file, it also checks the SHA-1 checksum that the repository publishes next to the file.

## **Third-Party Components**

Aspose.Slides for Java includes code and data from third-party components. They are part of the JAR file, not separate Maven artifacts, so `mvn dependency:tree` and other tools that read Maven dependencies do not list them. The JAR file contains the notice *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf*, which lists the components and their licenses:

| Component | License stated in the notice |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | MIT-style license |
| Mono | MIT license; some parts under other licenses that the notice lists |
| RSWOP.ICM color profile | Microsoft license terms |
| sRGB_v4_ICC_preference.icc color profile | ICC permission to use, copy, and distribute the unchanged file |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

To extract the notice from the JAR file, run the `jar` tool from the JDK in the folder that contains the JAR file:

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **FAQ**

**Does Aspose.Slides for Java use external packages?**

It has no Maven dependencies, as [Maven Dependencies](#maven-dependencies) shows, but it includes the third-party components listed in [Third-Party Components](#third-party-components). Include both the JAR file and these components in your security review.

**Does Aspose.Slides for Java need network access?**

No. Creating, saving, and rendering presentations work on a system without any network connection. The only feature that sends data to Aspose is [metered licensing](/slides/java/metered-licensing/), which reports API usage.

**Does Aspose.Slides for Java contain native code?**

No. The JAR file contains only Java classes and resources, so it adds no native libraries to your application. On Linux, the font support of the Java runtime needs the fontconfig library and fonts from the operating system; see [System Requirements](/slides/java/system-requirements/#linux).
