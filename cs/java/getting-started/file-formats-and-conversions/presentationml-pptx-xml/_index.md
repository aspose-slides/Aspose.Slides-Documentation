---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /cs/java/presentationml-pptx-xml/
---
{{% alert color="info" %}} 

PresentationML je název pro rodinu formátů založených na XML pro prezentační dokumenty. Office OpenXML (OOXML) je formát založený na XML, který byl zaveden v aplikacích Microsoft Office 2007. Office OpenXML je kontejnerový formát pro několik specializovaných jazyků značkování založených na XML. PresentationML je jazyk značkování používaný v Microsoft Office PowerPoint 2007 k ukládání dokumentů.

{{% /alert %}} 

## **PresentationML v Aspose.Slides for Java**
Dokumenty OOXML PresentationML jsou ve formě souborů PPTX, zipovaných XML balíčků, které odpovídají specifikaci [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for Java rozsáhle podporuje vytváření, čtení, manipulaci a zápis dokumentů PresentationML. Navíc Aspose.Slides for Java dokáže exportovat dokumenty PresentationML do široce používaného formátu jako PDF. To je možné, protože Aspose.Slides for Java byl navržen s cílem komplexně zpracovávat prezentační dokumenty a PresentationML v podstatě obsahuje interní prezentaci dokumentů jako zipovaný XML balíček.

**PPTX dokument vygenerovaný pomocí Aspose.Slides for Java a otevřený v Microsoft PowerPoint** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Zobrazení stejného PPTX dokumentu vygenerovaného pomocí Aspose.Slides for Java v archivu ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML je otevřený, proč používat Aspose.Slides for Java?**
Protože je PresentationML založen na XML, je naprosto možné vytvářet aplikace pro zpracování a generování dokumentů PresentationML pomocí XML tříd bez spoléhání se na knihovnu třetí strany, jako je Aspose.Slides for Java. Přesto existuje několik výhod používání Aspose.Slides for Java oproti XML třídám při práci s dokumenty PresentationML.

Specifikace OOXML má několik tisíc stran, takže pro řádné zpracování dokumentů PresentationML musíte věnovat hodně času a úsilí pochopení formátu. Na druhou stranu s Aspose.Slides for Java stačí použít třídy a jejich metody a vlastnosti k provádění operací, které by se zdály složité při použití XML tříd.

Některé funkce, které Aspose.Slides nabízí, nejsou ani dostupné při práci s dokumenty PresentationML pomocí XML tříd:

- Exportovat PPT dokumenty do formátu PDF.
- Vykreslit snímek do libovolného formátu obrázku podporovaného Java Frameworkem.
- Automaticky kopírovat master snímky ze zdrojové prezentace pomocí funkce klonování.
- Aplikovat ochranu na tvary.

Níže je příklad dokumentu PresentationML s jedním snímkem obsahujícím textové pole s textem „Hello World“. Pro načtení textu pomocí XML tříd musíte napsat program, který dokáže parsovat tento jednoduchý text z následujícího úryvku. Aspose.Slides to za vás provede.

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