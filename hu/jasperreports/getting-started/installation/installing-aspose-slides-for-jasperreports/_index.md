---
title: Az Aspose.Slides for JasperReports telepítése
type: docs
weight: 40
url: /hu/jasperreports/installing-aspose-slides-for-jasperreports/
description: "Válassza ki a JasperReports verziójához megfelelő Aspose.Slides for JasperReports jar fájlokat, és adja hozzá őket a JasperReports-hoz, egy Maven projekthez vagy a JasperReports Serverhez."
---
## **Válassza ki a jar fájlokat a JasperReports verziójához**

Aspose.Slides for JasperReports egy ZIP fájlként érhető el a [letöltési oldalon](https://releases.aspose.com/slides/hu/jasperreport/). A *lib* könyvtárában minden JasperReports verziótartományhoz van egy alkönyvtár. Vegye a jar fájlokat a megfelelő alkönyvtárból, amely lefedi a használt JasperReports verziót:

| JasperReports verzió | *lib* alkönyvtára |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

Nincs alkönyvtár a JasperReports 6.17.0 vagy újabb verziókhoz, beleértve a JasperReports 7-et. A *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* alkönyvtár nem tartalmaz jar fájlokat, csak egy megjegyzést, miszerint a támogatás ezekhez a verziókhoz a Aspose.Slides for JasperReports 17.6-ban véget ért.

Minden alkönyvtár két jar fájlt tartalmaz; a nevükben a *xx.x* a termék verzióját jelöli:

- *aspose.slides.jasperreports.library-xx.x.jar* tartalmazza a JasperReports Library exportereket (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` és `ASHtmlExporter`) és a `License` osztályt.
- *aspose.slides.jasperreports.server-xx.x.jar* tartalmazza a JasperReports Server export műveleteit. A könyvtári jarra épül, ezért a szervernek mindig mindkét jar fájlra van szüksége ugyanabból az alkönyvtárból.

## **Adja hozzá a könyvtári jar fájlt a JasperReports-hoz vagy az alkalmazásához**

Másolja a *aspose.slides.jasperreports.library-xx.x.jar* fájlt a megfelelő alkönyvtárból a JasperReports *lib* könyvtárába vagy az alkalmazás osztályútvonalára. Az alkalmazás ezután kódból létrehozhatja az exportereket.

{{% alert color="info" title="Megjegyzés" %}}
Linuxon a JasperReports-nek szüksége van a fontconfig-re és legalább egy telepített betűtípusra a jelentés kitöltéséhez. Betűtípusok nélkül a kitöltés a "Error initializing graphic environment" hibával meghiúsul.
{{% /alert %}}

## **Adja hozzá a könyvtári jar fájlt Maven projekthez**

A jar a ZIP-ben érkezik, nem Maven tárolóból. A Maven buildben való használathoz telepíteni kell a helyi Maven tárolóba. A 26.6 verzióhoz futtassa ezt a parancsot a jar-t tartalmazó mappában:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

Ezután adja hozzá a *pom.xml* függőségekhez, egy olyan JasperReports verzióval, amelyet a jar alkönyvtára támogat:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

A csoport- és artifact-azonosítók azok, amelyeket a telepítési parancsban megad, csak egyezniük kell. Egy teljes projekt, amely a JasperReports 6.16.0 verziót használja, megtalálható a [Az első exportja](/slides/hu/jasperreports/#your-first-export) oldalon.

## **Adja hozzá a jar fájlokat a JasperReports Serverhez**

Másolja mindkét jar fájlt a megfelelő alkönyvtárból a JasperReports Server webalkalmazás *WEB-INF/lib* könyvtárába, majd regisztrálja az exportereket a [Integráció a JasperServerrel](/slides/hu/jasperreports/integration-with-jasperserver/) leírása szerint.