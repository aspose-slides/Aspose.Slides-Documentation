---
title: Instalace Aspose.Slides pro JasperReports
type: docs
weight: 40
url: /cs/jasperreports/installing-aspose-slides-for-jasperreports/
description: "Vyberte jar soubory Aspose.Slides pro JasperReports, které odpovídají vaší verzi JasperReports, a přidejte je do JasperReports, Maven projektu nebo JasperReports Serveru."
---
## **Vyberte jar soubory pro vaši verzi JasperReports**

Aspose.Slides for JasperReports je distribuováno jako ZIP soubor na [download page](https://releases.aspose.com/slides/jasperreport/). Jeho složka *lib* obsahuje podsložku pro každý rozsah verzí JasperReports. Vezměte jar soubory ze složky, která odpovídá verzi JasperReports, kterou používáte:

| Verze JasperReports | Podsložka *lib* |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

Pro JasperReports 6.17.0 a novější, včetně JasperReports 7, neexistuje žádná podsložka. Podsložka *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* neobsahuje žádné jar soubory, pouze poznámku, že podpora těchto verzí skončila v Aspose.Slides for JasperReports 17.6.

Každá podsložka obsahuje dva jar soubory; *xx.x* v jejich názvech je verze produktu:

- *aspose.slides.jasperreports.library-xx.x.jar* obsahuje exportéry pro JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` a `ASHtmlExporter`) a třídu `License`.
- *aspose.slides.jasperreports.server-xx.x.jar* obsahuje exportní akce pro JasperReports Server. Navazuje na knihovní jar, takže server vždy potřebuje oba jar soubory ze stejné podsložky.

## **Přidejte knihovní jar do JasperReports nebo do své aplikace**

Zkopírujte *aspose.slides.jasperreports.library-xx.x.jar* z odpovídající podsložky do složky *lib* JasperReports nebo do classpath vaší aplikace. Vaše aplikace pak může v kódu vytvořit exportéry.

{{% alert color="info" title="Note" %}}
Na Linuxu JasperReports potřebuje fontconfig a alespoň jeden nainstalovaný font pro vyplnění reportu. Bez fontů selže vyplňování s chybou "Error initializing graphic environment".
{{% /alert %}}

## **Přidejte knihovní jar do Maven projektu**

Jar soubor je součástí ZIP archiv, nikoli Maven repozitáře. Pro použití ve stavbě Maven jej nainstalujte do místního Maven repozitáře. Pro verzi 26.6 spusťte tento příkaz ve složce, která obsahuje jar:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

Poté jej přidejte do závislostí v *pom.xml* spolu s verzí JasperReports, kterou odpovídá podsložka jaru:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

Group a artifact ID jsou ty, které zadáte v instalačním příkazu; stačí, aby se shodovaly. Kompletní projekt používající JasperReports 6.16.0 najdete v [Your first export](/slides/cs/jasperreports/#your-first-export).

## **Přidejte jar soubory do JasperReports Serveru**

Zkopírujte oba jar soubory z odpovídající podsložky do složky *WEB-INF/lib* webové aplikace JasperReports Server a poté zaregistrujte exportéry podle popisu v [Integration with JasperServer](/slides/cs/jasperreports/integration-with-jasperserver/).