---
title: Installing Aspose.Slides for JasperReports
type: docs
weight: 40
url: /jasperreports/installing-aspose-slides-for-jasperreports/
description: "Choose the Aspose.Slides for JasperReports jars that match your JasperReports version, and add them to JasperReports, a Maven project or JasperReports Server."
---

## **Choose the jars for your JasperReports version**

Aspose.Slides for JasperReports is distributed as a ZIP file on the [download page](https://releases.aspose.com/slides/jasperreport/). Its *lib* folder has one subfolder per range of JasperReports versions. Take the jars from the subfolder that covers the JasperReports version you use:

| JasperReports version | Subfolder of *lib* |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

There is no subfolder for JasperReports 6.17.0 or later, including JasperReports 7. The *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* subfolder holds no jars, only a note that support for those versions ended in Aspose.Slides for JasperReports 17.6.

Each subfolder holds two jars; *xx.x* in their names is the product version:

- *aspose.slides.jasperreports.library-xx.x.jar* contains the exporters for JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` and `ASHtmlExporter`) and the `License` class.
- *aspose.slides.jasperreports.server-xx.x.jar* contains the export actions for JasperReports Server. It builds on the library jar, so the server always needs both jars from the same subfolder.

## **Add the library jar to JasperReports or your application**

Copy *aspose.slides.jasperreports.library-xx.x.jar* from the matching subfolder to the *lib* folder of JasperReports or to your application's classpath. Your application can then create the exporters in code.

{{% alert color="info" title="Note" %}}
On Linux, JasperReports needs fontconfig and at least one installed font to fill a report. Without fonts, filling fails with the error "Error initializing graphic environment".
{{% /alert %}}

## **Add the library jar to a Maven project**

The jar comes in the ZIP rather than from a Maven repository. To use it in a Maven build, install it into your local Maven repository. For version 26.6, run this command in the folder that holds the jar:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

Then add it to the dependencies in *pom.xml*, together with a JasperReports version that the jar's subfolder covers:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

The group and artifact IDs are the ones you choose in the install command; they only have to match. A complete project that uses JasperReports 6.16.0 is in [Your first export](/slides/jasperreports/#your-first-export).

## **Add the jars to JasperReports Server**

Copy both jars from the matching subfolder to the *WEB-INF/lib* folder of the JasperReports Server web application, then register the exporters as described in [Integration with JasperServer](/slides/jasperreports/integration-with-jasperserver/).
