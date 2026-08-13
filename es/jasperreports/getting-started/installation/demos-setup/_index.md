---
title: Configuración de Demos
type: docs
weight: 70
url: /es/jasperreports/demos-setup/
---
Todas las demos proporcionadas con Aspose.Slides para JasperReports son demos estándar modificadas. Es mejor copiar todas las demos a la carpeta de demos de JasperReports:
...\jasperreports-x.x.x\demo\samples\

Utilice la secuencia estándar de comandos para compilar y exportar los informes:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 

Por favor, no olvide ejecutar HSQLDB con la base de datos de prueba para rellenar los informes con datos y copiar aspose.slides.jasperreports.library-xx.x.jar desde la carpeta \lib\JasperReports X.X.X - X.X.X del archivo aspose-slides-xx.x-jasperreports.zip a &#60;InstallDir&#62;\lib.

{{% /alert %}} 

La mayoría de las demos (excepto Charts) ya tienen presentaciones generadas, por lo que puede omitir todos los pasos “ant” y comprobar los resultados inmediatamente.