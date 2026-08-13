---
title: Nastavení demoverzí
type: docs
weight: 70
url: /cs/jasperreports/demos-setup/
---
Všechny demoverze poskytované s Aspose.Slides for JasperReports jsou upravené standardní demoverze. Je lepší zkopírovat všechny demoverze do složky demo JasperReports:
...\jasperreports-x.x.x\demo\samples\

Použijte standardní sekvenci příkazů pro sestavení a export zpráv:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 
Prosím, nezapomeňte spustit HSQLDB s testovací databází, aby se zprávy naplnily daty, a zkopírovat aspose.slides.jasperreports.library-xx.x.jar ze složky \lib\JasperReports X.X.X - X.X.X archivu aspose-slides-xx.x-jasperreports.zip do adresáře &#60;InstallDir&#62;\lib. 
{{% /alert %}} 

Většina demoverzí (kromě Charts) již má vygenerované prezentace, takže můžete přeskočit všechny kroky „ant“ a zkontrolovat výsledky okamžitě.