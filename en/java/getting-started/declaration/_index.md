---
title: Security Manager Requirements
type: docs
weight: 190
url: /java/declaration/
keywords:
- Security Manager
- security policy
- AllPermission
- permissions
- sandbox
- JDK 24
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Which Security Manager permissions Aspose.Slides for Java and the code that calls it need on Java 23 and earlier, and why there is nothing to configure on Java 24 and later."
---

## **Overview**

The Java Security Manager limits what code can do according to a security policy. Java 17 deprecated it for removal ([JEP 411](https://openjdk.org/jeps/411)), and Java 24 disabled it permanently ([JEP 486](https://openjdk.org/jeps/486)). This article explains what Aspose.Slides for Java needs when an application still runs with a Security Manager. If your application does not enable one, which is the default, there is nothing to configure.

## **Java 23 and Earlier**

When a Security Manager is enabled, the security policy must grant these permissions to the Aspose.Slides JAR file and to the application code that calls it:

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides reads system properties.
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides reads font files and other files.
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides starts operating-system programs, for example `reg` on Windows and `fc-match` on Linux.
- `java.io.FilePermission` with the `write` action for the folders where your application saves files.

Granting the permissions to the JAR file alone is not enough: the code that calls Aspose.Slides needs them too. Granting `java.security.AllPermission` to both also works.

Without the permission to read system properties or to start programs, Aspose.Slides fails on first use: creating a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) object throws an `ExceptionInInitializerError`. Without read access to the font files, saving a presentation as PDF fails with the error "Cannot find any fonts installed on the system".

## **Java 24 and Later**

The Security Manager cannot be enabled on Java 24 and later, so there are no permissions to grant. Aspose.Slides runs with the permissions of the account that runs your application. To restrict what an application can access, the OpenJDK project recommends technologies outside the JDK, such as containers, hypervisors, and operating-system sandboxing features. See [JEP 486](https://openjdk.org/jeps/486).

## **FAQ**

**Can I use Aspose.Slides in an environment that runs applications under a restrictive Security Manager policy?**

Only if the policy grants the permissions listed above both to Aspose.Slides and to the code that calls it. They include reading all files and starting any program.
