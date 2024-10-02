---
title: Demos Setup
type: docs
weight: 70
url: /jasperreports/demos-setup/
---


All demos provided with Aspose.Slides for JasperReports are changed standard demos. It’s better to copy all demos to the JasperReports demo folder:
...\jasperreports-x.x.x\demo\samples\

Use standard commands sequence to build and export reports:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="primary" %}} 

Please do not forget to run HSQLDB with the test database to fill the reports with data and copy aspose.slides.jasperreports.library-xx.x.jar from the \lib\JasperReports X.X.X - X.X.X folder of aspose-slides-xx.x-jasperreports.zip to &#60;InstallDir&#62;\lib directory.

{{% /alert %}} 

Most demos (except Charts) already have generated presentations so you can skip all “ant” steps and check the results immediately.

