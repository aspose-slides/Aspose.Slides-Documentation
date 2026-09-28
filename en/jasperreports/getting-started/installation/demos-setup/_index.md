---
title: Demos Setup
type: docs
weight: 70
url: /jasperreports/demos-setup/
description: "Set up the demo projects from the Aspose.Slides for JasperReports download, change the exporter class they use, and build them with Ant."
---

## **What the demos are**

The *samples* folder of the Aspose.Slides for JasperReports download has eight demo projects: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* and *xmldatasource*. They are standard JasperReports demos, changed to add a `ppt` build target that exports the filled report to PPT. The download contains no exported presentations; you create them by building a demo.

## **Change the exporter class before you build**

As shipped, the demos' Java code uses `com.aspose.slides.jasperreports.JRPptExporter`, a class that the current jars do not contain, so the demos do not compile. In the demo's application class (for example, *ShapesApp.java* in the *shapes* demo), replace `JRPptExporter` with `ASPptExporter`, the PPT exporter in the same package. The *fonts* demo imports the whole package, so only the class name in its code changes.

The demos also use JasperReports classes that later JasperReports versions removed, such as `JExcelApiExporter` and `JRExporterParameter.FONT_MAP`. With the change above, the demos compile as follows:

| JasperReports version | Demos that compile |
| :- | :- |
| 5.5.1 | all eight |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* and *xmldatasource* |
| 6.16.0 | *charts* |

## **Build a demo**

Each demo's *build.xml* expects the folder layout of a JasperReports project: it compiles against *../../../build/classes* and the jars in *../../../lib*, relative to the demo folder.

1. Copy the demo folder to *demo/samples* in your JasperReports project folder.
2. Copy *aspose.slides.jasperreports.library-xx.x.jar* from the download's *lib* subfolder that covers your JasperReports version to the *lib* folder of the JasperReports project. See [Installing Aspose.Slides for JasperReports](/slides/jasperreports/installing-aspose-slides-for-jasperreports/).
3. Put the jar of your JasperReports version and the jars it depends on in the same *lib* folder. Besides the demo files, *build.xml* puts only *build/classes* and the jars under *lib* on the classpath, and *build/classes* holds JasperReports classes only after you compile JasperReports from source.
4. The *charts*, *subreport* and *text* demos read the HSQLDB sample database of JasperReports (`jdbc:hsqldb:hsql://localhost`), so start its server first, as described in *samples/Readme.txt* of the download. The other demos need no database.
5. In the demo folder, compile the application, compile the report design, fill it, and export it to PPT:

```bash
ant javac
ant compile
ant fill
ant ppt
```

The `ppt` target writes the presentation next to the filled report, named after the report (for example, *LandscapeReport.ppt*).

Two demos need more than the steps above:

- The *images* demo loads one picture from `http://jasperreports.sourceforge.net/jasperreports.png` when it exports. That address now redirects to HTTPS, so the `ppt` step writes no presentation until you change the address to `https://` in *ImagesReport.jrxml*. With JasperReports 6.4.0, exporting that picture fails even over HTTPS.
- The *xmldatasource* report uses the Arial font. On a system without Arial, `ant fill` prints that the font "is not available to the JVM" and writes no filled report, so `ant ppt` has nothing to export. The build still reports success, so check the output of each step.
