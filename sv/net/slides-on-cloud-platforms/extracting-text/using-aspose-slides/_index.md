---
title: "Hur man extraherar text från PPT, PPTX och ODP med Aspose.Slides"
linktitle: "Bildspel"
type: docs
weight: 30
url: /sv/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- "molnplattformar"
- "molnintegration"
- "textextraktion"
- "extrahera text"
- "PPT"
- "PPTX"
- "ODP"
- "presentationsfiler"
- "plattformoberoende"
- "Office‑oberoende"
- "anteckningar och kommentarer"
- "företagsindexering"
- "databerikning"
- ".NET"
- "Aspose.Slides"
description: "Extrahera text från presentationer på populära molnplattformar med Aspose.Slides API:er, automatisera sökning, analys och export för PPT, PPTX och ODP."
---
## **Introduktion**

Aspose.Slides tillhandahåller ett **kraftfullt, högkvalitativt API** för att extrahera text från presentationsfiler, inklusive **PPT, PPTX och ODP**. Till skillnad från Open XML SDK – som endast stöder PPTX och kräver komplex XML‑parsing – förenklar Aspose.Slides textutvinning, så att du kan fokusera på att integrera den extraherade innehållet i dina arbetsflöden.

## **Snabb textutvinning med PresentationFactory.Instance.GetPresentationText**

För att extrahera text från en presentation erbjuder **Aspose.Slides‑API** den statiska metoden `PresentationFactory.Instance.GetPresentationText`. Den innehåller flera överlagringar för att arbeta med en presentationsfil eller ett datastream, och fångar text från **bilder, masterbilder, layouter, anteckningar och kommentarer**. Den extraherade texten nås via gränssnittet `IPresentationText`.

```csharp
string filePath = "presentation.pptx";
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Unarranged;

IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text: " + slideText.Text);
    Console.WriteLine("Notes Text: " + slideText.NotesText);
    Console.WriteLine("Comments Text: " + slideText.CommentsText);
}
```

## **Driftslägen för GetPresentationText**

`GetPresentationText`‑metoden i `PresentationFactory` låter dig finjustera textutvinning med hjälp av parametern `TextExtractionArrangingMode`, som styr hur texten organiseras i resultatet.

### **Tillgängliga lägen**

- **TextExtractionArrangingMode.Unarranged** – Extraherar text på ett fritt sätt, utan att ta hänsyn till den ursprungliga bildlayouten.  
- **TextExtractionArrangingMode.Arranged** – Behåller textordningen enligt dess placering på varje bild.

Exempel på användning:

```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```

## **Viktiga fördelar med PresentationFactory‑metoder**

- **Ingen behov av att ladda hela presentationer**: Minskar minnesanvändning och ökar bearbetningshastigheten.  
- **Optimerad för stora filer**: Hanterar även omfattande presentationer effektivt och extraherar text snabbt.  
- **Hämtar anteckningar och kommentarer**: Inkluderar användaranteckningar för fullständig innehållstäckning.  
- **Idealisk för indexering och innehållsanalys**: Perfekt för företagsystem som kräver automatiserad bearbetning och dataförbättring.  
- **Office‑oberoende**: Fungerar utan Microsoft PowerPoint installerat och erbjuder en verkligt fristående lösning.  
- **Stöd för flera format**: Fungerar sömlöst med **PPT, PPTX och ODP**.  
- **Flexibelt, kraftfullt API**: Tillhandahåller mångsidiga metoder för strukturerad textutvinning.  
- **Fullständig bildtäckning**: Extraherar text från **layouter, masterbilder, standardbilder, bakgrunder, talaranteckningar och kommentarer**.  
- **Plattformsoberoende kompatibilitet**: Fungerar på **Windows, Linux, macOS** samt i molnmiljöer.  
- **Hög prestanda och skalbarhet**: Lämplig för **SaaS‑applikationer** och storskaliga företagsdistributioner.

## **Stödda operativsystem**

Aspose.Slides körs på en rad olika operativsystem:

- **Windows** (t.ex. Windows 7, 8, 10, 11 och Server‑utgåvor)  
- **Linux** (olika distributioner, inklusive Ubuntu, Debian, Fedora, CentOS etc.)  
- **macOS** (inklusive moderna versioner som 10.15 Catalina och senare)  

## **Stödda programmeringsspråk**

Aspose.Slides integreras med flera plattformar och språk:

- **C#** – Primärt stöd via Aspose.Slides för .NET.  
- **Java** – Fullständig API tillgänglig med Aspose.Slides för Java.  
- **C++** – Använd Aspose.Slides för prestandakritiska C++‑applikationer.  
- **Python via .NET** – Integrera Aspose.Slides‑funktionalitet med .NET‑interoperabilitet.  
- **Andra .NET‑kompatibla språk** – Använd biblioteket i vilken miljö som helst som stöds av .NET.

## **Slutsats**

Aspose.Slides levererar **omfattande textutvinning** för PowerPoint‑ och OpenDocument‑presentationer, med stöd för **olika filformat, intuitiv textstrukturering och enkel implementering** jämfört med Open XML SDK. Från **bilder och anteckningar till mallinnehåll** är **Aspose.Slides** en högpresterande, funktionsrik lösning för att extrahera och hantera presentations‑text.