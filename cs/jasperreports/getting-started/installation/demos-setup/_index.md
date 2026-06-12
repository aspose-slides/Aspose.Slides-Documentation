---
title: Nastavení dem
type: docs
weight: 70
url: /cs/jasperreports/demos-setup/
---
Všechny demoverze poskytované s Aspose.Slides pro JasperReports jsou upravené standardní demoverze. Je lepší zkopírovat všechny demoverze do složky s demy JasperReports:
...\jasperreports-x.x.x\demo\samples\

Použijte standardní sekvenci příkazů pro sestavení a exportování zpráv:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="primary" %}} 

Prosím, nezapomeňte spustit HSQLDB s testovací databází, aby se zprávy naplnily daty, a zkopírovat aspose.slides.jasperreports.library-xx.x.jar ze složky \lib\JasperReports X.X.X - X.X.X v archivu aspose-slides-xx.x-jasperreports.zip do &#60;InstallDir&#62;\lib adresáře.

{{% /alert %}} 

Většina demoverzí (kromě Grafů) již má vygenerované prezentace, takže můžete přeskočit všechny kroky „ant“ a okamžitě zkontrolovat výsledky.