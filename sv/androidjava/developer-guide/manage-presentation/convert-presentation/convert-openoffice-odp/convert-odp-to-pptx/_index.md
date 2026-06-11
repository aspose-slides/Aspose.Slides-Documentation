---
title: Konvertera ODP till PPTX på Android
linktitle: ODP till PPTX
type: docs
weight: 10
url: /sv/androidjava/convert-odp-to-pptx/
keywords:
- konvertera OpenDocument
- konvertera presentation
- konvertera bild
- konvertera ODP
- OpenDocument till PPTX
- ODP till PPTX
- spara ODP som PPTX
- exportera ODP till PPTX
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Konvertera ODP till PPTX med Aspose.Slides för Android. Ren Java-kodexempel, batchtips och resultat av hög kvalitet—ingen PowerPoint behövs."
---
## **Översikt**

Den här artikeln förklarar hur man konverterar en ODP-presentation till PPTX-format med Aspose.Slides.

## **Konvertera ODP till PPTX/PPT-presentation**
Aspose.Slides for Android via Java erbjuder klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) som representerar en presentationsfil. Klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) kan nu också komma åt ODP genom [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-)‑konstruktorn när objektet instansieras. Följande exempel visar hur man konverterar en ODP-presentation till en PPTX-presentation.

```java
// Öppna ODP-filen
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Spara ODP-presentationen i PPTX-format
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Live-exempel**
Du kan besöka webappen [**Aspose.Slides Conversion**](https://products.aspose.app/slides/sv/conversion/) som är byggd med **Aspose.Slides API**. Appen demonstrerar hur konvertering från ODP till PPTX kan implementeras med Aspose.Slides API.

## **FAQ**

**Behöver jag installera Microsoft PowerPoint eller LibreOffice för att konvertera ODP till PPTX?**

Nej. Aspose.Slides fungerar fristående och kräver inga tredjepartsapplikationer för att läsa eller skriva ODP/PPTX.

**Bevaras masterbilder, layouter och teman vid konvertering?**

Ja. Biblioteket använder en fullständig presentationsobjektmodell och behåller strukturen, inklusive masterbilder och layouter, så designen förblir korrekt efter konverteringen.

**Kan jag konvertera lösenordsskyddade ODP-filer?**

Ja. Aspose.Slides stöder upptäckt av skydd, öppning och arbete med [protected presentations](/slides/sv/androidjava/password-protected-presentation/) (inklusive ODP) när du anger lösenordet, samt konfiguration av kryptering och åtkomst till dokumentegenskaper.

**Är Aspose.Slides lämplig för moln- eller REST-baserade konverteringstjänster?**

Ja. Du kan använda det lokala biblioteket i din egen backend eller [Aspose.Slides Cloud](https://products.aspose.cloud/slides/sv/family/) (REST API); båda alternativen stödjer konvertering från ODP → PPTX.