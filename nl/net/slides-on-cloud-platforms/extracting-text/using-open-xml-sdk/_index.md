---
title: "Hoe tekst te extraheren uit PPT‑, PPTX‑ en ODP‑bestanden met Open XML SDK in .NET"
linktitle: "Open XML SDK"
type: docs
weight: 20
url: /nl/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- cloudplatformen
- cloudintegratie
- Open XML SDK
- PPTX-tekstextractie
- .NET dia verwerking
- presentatietekstextractie
- masterdia
- sprekerbijschriften
- tekst uit dia's extraheren
- C#
description: "Leer hoe u tekst kunt extraheren uit PPT‑, PPTX‑ en ODP‑bestanden in .NET met behulp van Open XML SDK, met XML‑gebaseerde toegang, prestatie‑tips en conversie‑oplossingen voor cloud‑apps."
---
## **Overzicht**

Dit artikel legt uit hoe u tekst uit presentatiebestanden kunt extraheren met behulp van de Open XML SDK in .NET. Het richt zich op directe XML-toegang voor PPTX‑bestanden, waarbij tekst kan worden opgehaald uit gestructureerde dia‑elementen zonder de dia’s te renderen of Microsoft PowerPoint te vereisen. Het artikel beschrijft ook prestatievoordelen zoals snellere verwerking en een lager geheugenverbruik.

Voor PPT‑ en ODP‑bestanden legt het artikel uit dat tekst niet rechtstreeks met de Open XML SDK kan worden geëxtraheerd. Deze formaten moeten eerst worden geconverteerd naar PPTX, waarna de tekst uit het resulterende bestand kan worden gehaald.

## **Open XML SDK**

De **Open XML SDK** biedt een sterk gestructureerde en efficiënte methode om tekst uit presentatiebestanden te extraheren – vooral **PPTX**, dat voldoet aan de Open XML‑standaard. Door directe toegang tot de onderliggende XML maakt deze SDK sneller en flexibeler omgaan met dia‑inhoud mogelijk dan traditionele methoden.

## **Directe XML-toegang**

- **Analyseer Tekst Direct**: De Open XML SDK stelt u in staat tekst te extraheren uit XML‑onderdelen zonder dia’s te renderen.  
- **Gestructureerde Elementen**: Omdat tekst wordt opgeslagen in duidelijk gedefinieerde XML‑tags, is het eenvoudiger om deze op te halen en te verwerken.

### **Voorbeeld: Direct Tekst Extraheren uit Dia‑XML‑Inhoud**

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

## **Prestatievoordelen**

- **Snellere Extractie**: Omzeilt de overhead van het openen van PowerPoint of andere high‑level API’s.  
- **Lager Geheugenverbruik**: Alleen relevante XML‑onderdelen worden benaderd, waardoor het resource‑verbruik wordt verminderd.  
- **Geen Microsoft PowerPoint Vereist**: U hoeft geen extra installatievereisten te hebben.

### **Voorbeeld: Efficiënt Tekst Extraheren zonder de Complete Presentatie te Laden**

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

## **Identificeren van Tekstelementen**

### **Specificaties voor het Extraheren van Tekst uit Presentaties**

Bij het extraheren van tekst uit presentaties dient u rekening te houden met de volgende aspecten:

- **Tekst kan zich in verschillende secties bevinden**: Reguliere dia’s, master‑dia’s, lay‑outs of notities van de spreker.  
- **Standaardplaatsaanduidingen**: Master‑dia’s en lay‑outs kunnen plaatsaanduidingen bevatten (bijv. “Klik om de Master‑titelstijl te bewerken”) die geen daadwerkelijke presentatietekst zijn.  
- **Lege of verborgen tekst filteren**: Sommige elementen kunnen leeg zijn of niet bedoeld voor weergave.

### **Tags die Tekst Bevatten**

In een **PPTX**‑bestand wordt tekst over het algemeen opgeslagen in:
- `<a:t>`‑elementen binnen `<a:p>` (alinea’s)  
- `<a:r>`‑elementen (tekstsegmenten binnen alinea’s)

### **Voorbeeld: Alle Tekstelementen uit een Dia Extraheren**

```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```

## **ODP en PPT**

### **Onmogelijkheid om Tekst Direct te Extraheren**

- In tegenstelling tot **PPTX** worden **PPT** (binair formaat) en **ODP** (OpenDocument Presentation) **niet ondersteund** door de Open XML SDK.  
- **PPT** slaat inhoud op in een gesloten binair formaat, wat het extraheren van tekst bemoeilijkt.  
- **ODP** maakt gebruik van **OpenDocument XML**, dat structureel verschilt van PPTX.

### **Oplossing: Converteren naar PPTX**

Om tekst uit **PPT** of **ODP** te extraheren, wordt de volgende aanpak aanbevolen:

1. **Converteer PPT → PPTX** met PowerPoint of een extern hulpmiddel.  
2. **Converteer ODP → PPTX** via LibreOffice of PowerPoint.  
3. **Extraheren van tekst** uit de nieuwe PPTX met de Open XML SDK.

### **Voorbeeld: ODP Converteren naar PPTX via LibreOffice Commandoregel**

```sh
soffice --headless --convert-to pptx presentation.odp
```

## **Ondersteunde Platforms en Frameworks**

- **Windows**: .NET Framework 4.6.1 en hoger, .NET Core 2.1+, .NET 5/6/7.  
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.  
- **Cloudomgevingen**: Microsoft Azure Functions, AWS Lambda (.NET Core), Docker‑containers.  
- **Compatibiliteit met Office‑toepassingen**: Geen installatie van Microsoft Office nodig.  
- **Ondersteunde programmeertalen**: Open XML SDK kan worden gebruikt met **C#**, **VB.NET**, **F#**, en andere door .NET ondersteunde talen.

## **Conclusie**

Het gebruik van de **Open XML SDK** voor **PPTX‑tekstextractie** biedt zowel efficiëntie als helderheid, terwijl **PPT** en **ODP** een eerste conversiestap vereisen voor een soepele verwerking. Deze aanpak garandeert **hoge prestaties**, **flexibiliteit** en **brede compatibiliteit** met moderne .NET‑toepassingen.