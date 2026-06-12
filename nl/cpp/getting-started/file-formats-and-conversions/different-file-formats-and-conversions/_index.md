---
title: Verschillende bestandsformaten en conversies
type: docs
weight: 50
url: /nl/cpp/different-file-formats-and-conversions/
---
## **Microsoft PowerPoint (PPT)**
### **Over PPT**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint) is het presentatiedocumentformaat dat kan worden aangemaakt, gelezen, bewerkt en weggeschreven door verschillende versies van Microsoft PowerPoint. Het betreft het binaire formaat voor presentatiedocumenten dat door Microsoft is ontwikkeld.
### **PPT in Aspose.Slides for C++**
Aspose.Slides for C++ kan PPT‑bestanden lezen die zijn aangemaakt met de onderstaande software.

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

Evenzo kunnen PPT‑bestanden die zijn aangemaakt met Aspose.Slides for C++ gelezen worden door de bovenstaande software.
### **Uitgebreide ondersteuning voor PPT**
Aspose.Slides for C++ biedt ondersteuning voor bijna alle functies die verband houden met het PPT‑documentformaat. Het omvat niet alleen de basis‑ en geavanceerde functies die door de verschillende Microsoft PowerPoint‑versies worden geleverd voor PPT‑manipulatie, maar ook enkele functies die zelfs door Microsoft PowerPoint zelf niet worden ondersteund. Het belangrijkste voordeel van het gebruik van de Aspose.Slides for C++‑API‑bibliotheek is het gebruiksgemak bij het omgaan met deze functies.

Naast de basisbewerkingen voor het aanmaken, lezen en schrijven van PPT‑documentbestanden, biedt Aspose.Slides for C++ onder meer de volgende mogelijkheden:

- Andere MS‑Office‑bestandformaten importeren als OLE‑objecten in PPT‑documenten.
- PPT‑documenten exporteren naar PDF, TIFF, XPS‑formaten.
- Dia's in PPT‑documenten exporteren naar SVG‑formaten.
- Dia renderen naar elk afbeeldingsformaat dat door C++ Framework wordt ondersteund.
- Grootte van dia’s in het PPT‑document instellen.
- Animaties op vormen beheren.
- Diavoorstellingen beheren.
- Tekst op dia’s opmaken.
- Tekst scannen in PPT‑documenten.
- Tabellen op dia’s behandelen.
- Automatisch masters kopiëren met de kloon‑functie.

Een PPT‑bestand gegenereerd door Aspose.Slides for C++ en geopend in Microsoft PowerPoint
## **PresentationML (PPTX, XML)**
### **Over PresentationML**
PresentationML is de naam voor een familie van XML‑gebaseerde formaten voor presentatiedocumenten. Office OpenXML (OOXML) is het XML‑gebaseerde formaat dat is geïntroduceerd in de Microsoft Office 2007‑toepassingen. Office OpenXML is een containerformaat voor verschillende gespecialiseerde XML‑gebaseerde opmaak‑talen. PresentationML is de opmaaktaal die Microsoft Office PowerPoint 2007 gebruikt om zijn documenten op te slaan.
### **PresentationML in Aspose.Slides for C++**
OOXML PresentationML‑documenten zijn PPTX‑bestanden die gecomprimeerde XML‑pakketten zijn volgens de [OOXML ECMA‑376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/)‑specificaties. Aspose.Slides for C++ ondersteunt uitgebreid het aanmaken, lezen, bewerken en wegschrijven van PresentationML‑documenten. Daarnaast kan Aspose.Slides for C++ PresentationML‑documenten exporteren naar verschillende breed gebruikte documentformaten zoals PDF, TIFF en XPS. Dit is mogelijk omdat Aspose.Slides for C++ is ontworpen om presentatiedocumenten volledig af te handelen en PresentationML in wezen de interne weergave van documenten opslaat als een gecomprimeerd XML‑pakket.

Een PPTX‑document gegenereerd door Aspose.Slides for C++ en geopend in Microsoft PowerPoint

Weergave van een PPTX‑document gegenereerd door Aspose.Slides for C++ in een zip‑applicatie
### **PresentationML is open, waarom Aspose.Slides for C++ gebruiken**
Omdat PresentationML XML‑gebaseerd is, is het goed mogelijk om applicaties te bouwen die PresentationML‑documenten verwerken en genereren met XML‑klassen, zonder afhankelijk te zijn van derde‑partij‑bibliotheken zoals Aspose.Slides for C++. Er zijn echter diverse voordelen verbonden aan het gebruik van Aspose.Slides for C++ ten opzichte van XML‑klassen bij het werken met PresentationML‑documenten.

De OOXML‑specificatie beslaat duizenden pagina’s. Dat betekent dat je veel tijd en moeite moet besteden aan het begrijpen van het formaat van dergelijke documenten. Met Aspose.Slides for C++ hoef je alleen de relevante klassen en hun methoden/eigenschappen te gebruiken voor bewerkingen die via XML‑klassen behoorlijk complex lijken.

De volgende functies zijn zelfs niet beschikbaar wanneer je met PresentationML‑documenten werkt via XML‑klassen:

- PPT‑documenten exporteren naar PDF, TIFF, XPS‑formaten
- Dia's in PPT‑documenten exporteren naar SVG‑formaten
- Dia renderen naar elk afbeeldingsformaat dat door C++ Framework wordt ondersteund
- Automatisch masters kopiëren van bronpresentaties met de kloon‑functie
- Bescherming toepassen op vormen

Laten we een voorbeeld nemen van een PresentationML‑document met één dia en één tekstvak met de tekst “Hello World”. Om de tekst via XML‑klassen te lezen, moet je een programma schrijven dat deze eenvoudige tekst parseert vanuit het volgende fragment:

``` cpp

 <?xml version="1.0" encoding="UTF-8" standalone="yes"?>

<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">

  <p:cSld>

    <p:spTree>

      <p:nvGrpSpPr>

        <p:cNvPr id="1" name=""/>

        <p:cNvGrpSpPr/>

        <p:nvPr/>

      </p:nvGrpSpPr>

      <p:grpSpPr>

        <a:xfrm>

          <a:off x="0" y="0"/>

          <a:ext cx="0" cy="0"/>

          <a:chOff x="0" y="0"/>

          <a:chExt cx="0" cy="0"/>

        </a:xfrm></p:grpSpPr><p:sp>

          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>

          <p:cNvSpPr txBox="1"/>

            <p:nvPr/>

          </p:nvSpPr>

          <p:spPr>

            <a:xfrm>

              <a:off x="2819400" y="2590800"/>

              <a:ext cx="1297086" cy="369332"/>

            </a:xfrm>

            <a:prstGeom prst="rect">

              <a:avLst/>

            </a:prstGeom>

            <a:noFill/>

          </p:spPr>

          <p:txBody>

            <a:bodyPr wrap="none" rtlCol="0">

              <a:spAutoFit/>

            </a:bodyPr>

            <a:lstStyle/>

            <a:p>

              <a:r>

                <a:rPr lang="en-US"/>

                <a:t>Hello World

                </a:t>

              </a:r>

              <a:endParaRPr lang="en-US"/>

            </a:p>

          </p:txBody>

        </p:sp>

    </p:spTree>

  </p:cSld>

  <p:clrMapOvr>

    <a:masterClrMapping/>

  </p:clrMapOvr>

</p:sld>

```
## **PPT‑naar‑PPTX‑conversie**
### **Over conversie**
Aspose.Slides ondersteunt nu ook het converteren van PPT naar PPTX.
### **Functies die worden ondersteund bij conversie**
Aspose.Slides for C++ biedt gedeeltelijke ondersteuning voor het converteren van presentaties in PPT‑formaat naar presentaties in PPTX‑formaat. Omdat deze functie pas recent is geïntroduceerd in Aspose.Slides for C++, heeft hij momenteel een beperkte capaciteit en werkt hij alleen voor eenvoudige presentaties. Het belangrijkste voordeel van de Aspose.Slides for C++‑API‑bibliotheek voor het converteren van PPT‑presentaties naar PPTX‑presentaties is het gebruiksgemak van de API om het gewenste resultaat te behalen. Ga naar this[link]() voor de sectie met code‑fragmenten voor meer details. De onderstaande sectie geeft duidelijk weer welke functies wel en niet worden ondersteund bij het converteren van PPT‑presentaties naar PPTX‑presentaties.
### **Ondersteunde functies**
De volgende functies worden ondersteund tijdens conversie:

- Conversie van de structuur van masters, lay-outs en dia’s
- Conversie van de structuur van masters, lay-outs en dia’s
- Conversie van grafieken
- Groep‑vormen
- Conversie van auto‑vormen, inclusief rechthoeken en ellipsen. Het kan echter voorkomen dat auto‑vormen onjuiste aanpassingswaarden hebben
- Vormen met aangepaste geometrie. Soms niet geconverteerd
- Texturen en afbeeldingsvullingen voor auto‑vormen. Soms niet geconverteerd
- Conversie van place‑holders
- Conversie van tekst in tekstkaders en tekst‑holders. Kogels, uitlijning en tabs zijn echter niet volledig geïmplementeerd
### **Niet‑ondersteunde functies**
De volgende functies worden niet ondersteund tijdens conversie:

- Dia met notities, omdat het lezen van notities niet is geïmplementeerd in PPTX. Als PPT dit wel bevat, kan het nog niet worden opgeslagen als PPTX* Conversie van lijnen en polylijnen
- Lijn‑ en vulformaten
- Verloopvullingsstijlen
- OLE‑frames, tabellen, video‑ en audio‑frames enz.
- Animatie‑ en andere diavoorstellingseigenschappen worden overgeslagen
  Nieuwe of ontbrekende functies worden later toegevoegd in komende releases van Aspose.Slides for C++.

Bron‑PPT‑presentatie

Geconverteerde PPTX‑presentatie
## **Portable Document Format (PDF)**
### **Over PDF**
[Portable Document Format](https://en.wikipedia.org/wiki/PDF) is een bestandsformaat dat door Adobe System is gecreëerd voor uitwisseling van documenten tussen verschillende organisaties. Het doel van dit formaat is om mogelijk te maken dat de inhoud van documenten op een manier wordt weergegeven die visueel niet afhankelijk is van het platform waarop ze worden bekeken.
### **PDF in Aspose.Slides for C++**
Elk presentatiedocument dat kan worden geladen in Aspose.Slides for C++ kan worden geconverteerd naar een PDF‑document dat kan voldoen aan [PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) of [PDF /A‑1b](https://en.wikipedia.org/wiki/PDF/A), afhankelijk van je keuze. Aspose.Slides for C++ exporteert presentatiedocumenten naar PDF op een manier waardoor het geëxporteerde PDF‑document er in de meeste gevallen vrijwel identiek uitziet als het oorspronkelijke presentatiedocument. De Aspose‑oplossing ondersteunt de volgende kenmerken van presentatiedocumenten bij het converteren naar PDF‑documenten:

- Afbeeldingen, tekstvakken en andere vormen
- Tekst en opmaak
- Alinea’s en opmaak
- Hyperlinks
- Kop‑ en voetteksten
- Opsommingstekens
- Tabellen

Je kunt presentatiedocumenten direct exporteren naar PDF‑documenten met alleen de Aspose.Slides for C++‑component. Je hebt hiervoor geen andere derde‑partij‑ of Aspose.Pdf‑component nodig. Bovendien kun je de presentatie‑naar‑PDF‑export aanpassen met verschillende opties zoals uitgelegd in [this topic](/slides/nl/cpp/convert-powerpoint-to-pdf/).

Een presentatiedocument geconverteerd naar een PDF‑document via Aspose.Slides for C++
## **XML Parser Specification (XPS)**
### **Over XPS**
[XML Parser Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) is een paginabeschrijvingstaal en een vaste‑documentindeling die oorspronkelijk door Microsoft is ontwikkeld. Net als PDF is XPS een vast‑layout documentformaat dat is ontworpen om de nauwkeurigheid van documenten te behouden en een apparaat‑onafhankelijke weergave te bieden.
### **XPS in Aspose.Slides for C++**
Elk presentatiedocument dat kan worden geladen door Aspose.Slides for C++ kan worden geconverteerd naar XPS‑formaat. Aspose.Slides for C++ maakt gebruik van de high‑fidelity paginalay‑out‑ en rendermotor om output te produceren in het vaste‑layout XPS‑documentformaat. Het is vermeldenswaard dat Aspose.Slides for C++ XPS direct genereert zonder afhankelijk te zijn van de Windows Presentation Foundation (WPF)‑klassen die zijn verpakt met C++ Framework 3.5, waardoor Aspose.Slides for C++ XPS‑documenten kan produceren op machines met C++ Framework‑versies ouder dan 3.5. Meer informatie over het exporteren van presentatiedocumenten naar XPS‑documenten via Aspose.Slides for C++ vind je in [this topic](https://docs.aspose.com/slides/nl/cpp/convert-powerpoint-to-xps/).

Een presentatiedocument geconverteerd naar een XPS‑document via Aspose.Slides for C++