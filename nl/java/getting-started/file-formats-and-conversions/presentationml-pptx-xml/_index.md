---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /nl/java/presentationml-pptx-xml/
---
{{% alert color="info" %}} 
PresentationML is een benaming voor een familie van XML‑gebaseerde formaten voor presentatiedocumenten. Office OpenXML (OOXML) is het XML‑gebaseerde formaat dat geïntroduceerd werd in de Microsoft Office 2007‑toepassingen. Office OpenXML is een containerformaat voor meerdere gespecificeerde XML‑gebaseerde opmaak‑talen. PresentationML is de opmaaktaal die door Microsoft Office PowerPoint 2007 wordt gebruikt om documenten op te slaan.
{{% /alert %}} 
## **PresentationML in Aspose.Slides for Java**
OOXML PresentationML‑documenten worden geleverd als PPTX‑bestanden, gezipt XML‑pakketten die voldoen aan de [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) specificatie. Aspose.Slides for Java ondersteunt uitgebreid het maken, lezen, manipuleren en schrijven van PresentationML‑documenten. Bovendien kan Aspose.Slides for Java PresentationML‑documenten exporteren naar een veelgebruikt documentformaat zoals PDF. Dit is mogelijk omdat Aspose.Slides for Java is ontworpen met het doel om presentatiedocumenten volledig te verwerken en PresentationML in feite de interne presentatie van documenten bevat als een gezipt XML‑pakket.

**Een PPTX‑document gegenereerd door Aspose.Slides for Java en geopend in Microsoft PowerPoint** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Het bekijken van hetzelfde PPTX‑document dat door Aspose.Slides for Java is gegenereerd in een ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML is Open, waarom Aspose.Slides for Java gebruiken?**
Aangezien PresentationML XML‑gebaseerd is, is het zeker mogelijk om toepassingen te bouwen die PresentationML‑documenten verwerken en genereren met behulp van XML‑klassen zonder te vertrouwen op een externe bibliotheek zoals Aspose.Slides for Java. Er zijn echter verschillende voordelen verbonden aan het gebruik van Aspose.Slides for Java ten opzichte van XML‑klassen bij het werken met PresentationML‑documenten.

De OOXML‑specificatie beslaat enkele duizenden pagina’s, dus om PresentationML‑documenten correct te verwerken moet je veel tijd en moeite investeren om het formaat te begrijpen. Aan de andere kant hoef je met Aspose.Slides for Java alleen klassen en hun methoden en eigenschappen te gebruiken om handelingen uit te voeren die complex lijken wanneer ze via XML‑klassen worden gedaan.

Sommige van de functies die Aspose.Slides biedt, zijn zelfs niet beschikbaar wanneer je met PresentationML‑documenten werkt via XML‑klassen:
- Exporteren van PPT‑documenten naar PDF‑formaat.
- Een dia renderen naar elk afbeeldingsformaat dat door het Java‑framework wordt ondersteund.
- Automatisch masters kopiëren van een bronpresentatie met behulp van de kloon‑functie.
- Bescherming toepassen op vormen.

Hieronder staat een voorbeeld van een PresentationML‑document met één dia die een tekstvak bevat met de tekst “Hello World”. Om de tekst te lezen met XML‑klassen, moet je een programma schrijven dat deze eenvoudige tekst uit het volgende fragment kan parseren. Aspose.Slides doet dat voor jou.

**XML**

``` xml
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