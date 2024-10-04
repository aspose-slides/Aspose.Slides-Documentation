---
title: Configuración de Demos
type: docs
weight: 70
url: /jasperreports/demos-setup/
---

Todas las demos proporcionadas con Aspose.Slides para JasperReports son demos estándar modificadas. Es mejor copiar todas las demos a la carpeta de demos de JasperReports:  
...\jasperreports-x.x.x\demo\samples\

Utiliza la secuencia de comandos estándar para construir y exportar informes:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="primary" %}} 

Por favor, no olvides ejecutar HSQLDB con la base de datos de prueba para llenar los informes con datos y copiar aspose.slides.jasperreports.library-xx.x.jar de la carpeta \lib\JasperReports X.X.X - X.X.X del archivo aspose-slides-xx.x-jasperreports.zip al directorio &#60;InstallDir&#62;\lib.

{{% /alert %}} 

La mayoría de las demos (excepto Gráficas) ya tienen presentaciones generadas, por lo que puedes omitir todos los pasos de “ant” y verificar los resultados de inmediato.