---
title: PresentationML (PPTX, XML) (Historisch)
type: docs
weight: 20
url: /nl/java/presentationml-pptx-xml/
keywords:
- PresentationML
- PPTX
- Office Open XML
- historisch
- Java
- Aspose.Slides
description: "Historisch: een oudere beschrijving van het PresentationML (PPTX)-formaat in Aspose.Slides for Java, bewaard voor bestaande koppelingen. De huidige lijst met ondersteunde formaten vindt u in Ondersteunde bestandsformaten."
---
{{% alert color="info" title="Opmerking" %}}

Dit is een historische pagina, bewaard voor bestaande koppelingen. Het beschrijft niet de huidige versie van Aspose.Slides for Java. Voor de formaten die Aspose.Slides for Java laadt, importeert, opslaat en rendert, en de API voor elk van hen, zie [Ondersteunde bestandsformaten](/slides/nl/java/supported-file-formats/). Om PPTX met PPT te vergelijken, zie [Begrijpen van het verschil: PPT vs PPTX](/slides/nl/java/ppt-vs-pptx/).

{{% /alert %}}

{{% alert color="info" title="Opmerking" %}}

PresentationML is een naam voor een familie van op XML gebaseerde formaten voor presentatie‑documenten. Office OpenXML (OOXML) is het op XML‑gebaseerde formaat dat werd geïntroduceerd in Microsoft Office‑toepassingen vanaf 2007. Office OpenXML is een containerformaat voor verschillende gespecialiseerde op XML gebaseerde opmaak‑talen. PresentationML is de opmaaktaal die Microsoft Office PowerPoint 2007 gebruikt om documenten op te slaan.

{{% /alert %}}

## **PresentationML in Aspose.Slides voor Java**
OOXML PresentationML‑documenten komen voor als PPTX‑bestanden, gezipte XML‑pakketten die voldoen aan de [OOXML ECMA-376](https://ecma-international.org/publications-and-standards/standards/ecma-376/) specificatie. Aspose.Slides for Java ondersteunt uitgebreid het maken, lezen, manipuleren en schrijven van PresentationML‑documenten. Bovendien kan Aspose.Slides for Java PresentationML‑documenten exporteren naar een veelgebruikt documentformaat zoals PDF. Dit is mogelijk omdat Aspose.Slides for Java is ontworpen met als doel Presentation‑documenten volledig te kunnen verwerken en PresentationML in wezen de interne weergave van documenten bevat als een gezipt XML‑pakket.

**Een PPTX‑document gegenereerd door Aspose.Slides for Java en geopend in Microsoft PowerPoint**

![Een PPTX‑document gegenereerd door Aspose.Slides for Java en geopend in Microsoft PowerPoint](presentationml-pptx-xml_1.png)


**Hetzelfde PPTX‑document bekeken als een ZIP‑pakket**

![Hetzelfde PPTX‑document bekeken als een ZIP‑pakket](presentationml-pptx-xml_2.jpg)


## **PresentationML is open, waarom Aspose.Slides voor Java gebruiken?**
Omdat PresentationML op XML is gebaseerd, is het zeker mogelijk om applicaties te bouwen die PresentationML‑documenten verwerken en genereren met XML‑klassen zonder een externe bibliotheek zoals Aspose.Slides for Java te gebruiken. Er zijn echter verschillende voordelen aan het gebruik van Aspose.Slides for Java ten opzichte van XML‑klassen bij het werken met PresentationML‑documenten.

De OOXML‑specificatie telt duizenden pagina’s, dus om PresentationML‑documenten correct te verwerken moet je veel tijd en moeite investeren om het formaat te begrijpen. Met Aspose.Slides for Java gebruik je simpelweg klassen en hun methoden en eigenschappen om bewerkingen uit te voeren die complex lijken als ze via XML‑klassen worden gedaan.

Enkele functies die Aspose.Slides biedt en die niet beschikbaar zijn wanneer je met PresentationML‑documenten via XML‑klassen werkt:

- Exporteren van PPT‑documenten naar PDF‑formaat.
- Een dia renderen naar elk beeldformaat dat door het Java‑framework wordt ondersteund.
- Automatisch masters kopiëren uit een bronpresentatie met de kloonfunctie.
- Bescherming toepassen op vormen.

Hieronder staat een voorbeeld van een PresentationML‑document met één dia met een tekstvak met de tekst “Hello World”. Om de tekst met XML‑klassen te lezen, moet je een programma schrijven dat deze eenvoudige tekst kan parsen uit het volgende fragment. Aspose.Slides doet dat voor je.

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