---
title: "Hur man extraherar text från PPT-, PPTX- och ODP-filer med Open XML SDK i .NET"
linktitle: Open XML SDK
type: docs
weight: 20
url: /sv/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- molnplattformar
- molnintegration
- Open XML SDK
- PPTX textextraktion
- .NET bildbehandling
- presentations textextraktion
- masterbild
- föreläsarnoter
- extrahera text från bilder
- C#
description: "Lär dig hur du extraherar text från PPT, PPTX och ODP i .NET med Open XML SDK, med XML-baserad åtkomst, prestandatips och konverteringslösningar för molnappar."
---
## **Översikt**

Denna artikel förklarar hur man extraherar text från presentationsfiler med Open XML SDK i .NET. Den fokuserar på direkt XML‑åtkomst för PPTX‑filer, där text kan hämtas från strukturerade bild‑element utan att rendera bilder eller kräva Microsoft PowerPoint. Artikeln beskriver också prestandafördelar såsom snabbare bearbetning och lägre minnesanvändning.

För PPT‑ och ODP‑filer förklarar artikeln att text inte kan extraheras direkt med Open XML SDK. Istället måste dessa format först konverteras till PPTX, varefter texten kan extraheras från den resulterande filen.

## **Open XML SDK**

Open XML SDK erbjuder en mycket strukturerad och effektiv metod för att extrahera text från presentationsfiler — speciellt **PPTX**, som följer Open XML‑standarden. Genom att ge direkt åtkomst till den underliggande XML‑en möjliggör detta SDK snabbare och mer flexibel hantering av bildinnehåll jämfört med traditionella metoder.

## **Direkt XML‑åtkomst**

- **Analysera text direkt**: Open XML SDK låter dig extrahera text från XML‑delar utan att rendera bilder.
- **Strukturerade element**: Eftersom text lagras i väl definierade XML‑taggar är det enklare att hämta och bearbeta.

### **Exempel: Extrahera text direkt från bild‑XML‑innehåll**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```

## **Prestandafördelar**

- **Snabbare extraktion**: Förbigår overheaden av att öppna PowerPoint eller andra hög‑nivå‑API:er.
- **Lägre minnesanvändning**: Endast relevanta XML‑delar läses, vilket minskar resurserna.
- **Ingen Microsoft PowerPoint behövs**: Befriar dig från extra installationskrav.

### **Exempel: Effektiv extraktion av text utan att ladda hela presentationen**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```

## **Identifiera textelement**

### **Specifika detaljer för att extrahera text från presentationer**

När du extraherar text från presentationer, överväg följande faktorer:

- **Text kan finnas i olika sektioner**: Vanliga bilder, mastern bilder, layouter eller föreläsningsanteckningar.
- **Standard‑platshållare**: Mastern bilder och layouter kan innehålla platshållare (t.ex. ”Klicka för att redigera master‑titeln”) som inte är egentligt presentationsinnehåll.
- **Filtrering av tom eller dold text**: Vissa element kan vara tomma eller inte avsedda för visning.

### **Taggar som innehåller text**

I en **PPTX**‑fil lagras text vanligtvis i:

- `<a:t>`‑element inom `<a:p>` (paragrafer)
- `<a:r>`‑element (textsegment inom paragrafer)

### **Exempel: Extrahera alla textelement från en bild**

```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```

## **ODP och PPT**

### **Oförmåga att extrahera text direkt**

- Till skillnad från **PPTX**, stöds **PPT** (binärt format) och **ODP** (OpenDocument Presentation) **inte** av Open XML SDK.
- **PPT** lagrar innehåll i ett slutet binärt format, vilket försvårar textutdrag.
- **ODP** bygger på **OpenDocument XML**, som strukturellt skiljer sig från PPTX.

### **Alternativ: Konvertera till PPTX**

För att extrahera text från **PPT** eller **ODP** rekommenderas följande tillvägagångssätt:

1. **Konvertera PPT → PPTX** med PowerPoint eller ett tredjepartsverktyg.  
2. **Konvertera ODP → PPTX** via LibreOffice eller PowerPoint.  
3. **Extrahera text** från den nya PPTX‑filen med Open XML SDK.

### **Exempel: Konvertera ODP till PPTX via LibreOffice kommandorad**

```sh
soffice --headless --convert-to pptx presentation.odp
```

## **Stödda plattformar och ramverk**

- **Windows**: .NET Framework 4.6.1 och högre, .NET Core 2.1+, .NET 5/6/7.
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.
- **Molnmiljöer**: Microsoft Azure Functions, AWS Lambda (.NET Core), Docker‑behållare.
- **Kompatibilitet med Office‑program**: Ingen Microsoft Office‑installation krävs.
- **Stödda programmeringsspråk**: Open XML SDK kan användas med **C#**, **VB.NET**, **F#**, och andra .NET‑stödda språk.

## **Slutsats**

Att utnyttja **Open XML SDK** för **PPTX‑textextraktion** ger både effektivitet och tydlighet, medan **PPT** och **ODP** kräver ett initialt konverteringssteg för smidig bearbetning. Att anta detta tillvägagångssätt säkerställer **hög prestanda**, **flexibilitet** och **bred kompatibilitet** med moderna .NET‑applikationer.