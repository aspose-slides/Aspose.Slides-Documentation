---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /cs/java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 

PresentationML je název pro rodinu na XML založených formátů pro prezentační dokumenty. Office OpenXML (OOXML) je na XML založený formát zavedený v aplikacích Microsoft Office 2007. Office OpenXML je kontejnerový formát pro několik specializovaných jazyků založených na XML. PresentationML je značkovací jazyk používaný Microsoft Office PowerPoint 2007 k ukládání dokumentů.

{{% /alert %}} 

## **PresentationML v Aspose.Slides pro Java**
OOXML PresentationML dokumenty přicházejí ve formě souborů PPTX, zipovaných XML balíčků, které odpovídají specifikaci [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides pro Java rozsáhle podporuje vytváření, čtení, manipulaci a zápis PresentationML dokumentů. Navíc Aspose.Slides pro Java dokáže exportovat PresentationML dokumenty do široce používaného formátu PDF. Toto je možné, protože Aspose.Slides pro Java bylo navrženo s cílem komplexně zpracovávat prezentační dokumenty a PresentationML v podstatě obsahuje interní prezentaci dokumentů jako zipovaný XML balíček.

**Dokument PPTX vygenerovaný pomocí Aspose.Slides pro Java a otevřený v Microsoft PowerPoint** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Zobrazení stejného dokumentu PPTX vygenerovaného pomocí Aspose.Slides pro Java v ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML je otevřený, proč používat Aspose.Slides pro Java?**
Protože PresentationML je založeno na XML, je možné vytvořit aplikace pro zpracování a generování PresentationML dokumentů pomocí XML tříd bez spoléhání se na knihovnu třetí strany, jako je Aspose.Slides pro Java. Přesto existuje několik výhod použití Aspose.Slides pro Java oproti XML třídám při práci s PresentationML dokumenty.

Specifikace OOXML má několik tisíc stran, takže pro řádné zpracování PresentationML dokumentů musíte věnovat hodně času a úsilí pochopení formátu. Na druhou stranu s Aspose.Slides pro Java používáte jen třídy a jejich metody a vlastnosti k provádění operací, které by se jevily složitě, pokud by byly prováděny pomocí XML tříd.

Některé funkce, které Aspose.Slides nabízí, nejsou ani dostupné, když pracujete s PresentationML dokumenty přes XML třídy:

- Export PPT dokumentů do formátu PDF.
- Vykreslení snímku do libovolného formátu obrazu podporovaného Java Frameworkem.
- Automatické kopírování hlavních snímků ze zdrojové prezentace pomocí funkce klonování.
- Aplikace ochrany na tvary.

Níže je ukázka PresentationML dokumentu s jediným snímkem obsahujícím textové pole s textem „Hello World“. Pro přečtení textu pomocí XML tříd musíte napsat program, který dokáže parsovat tento jednoduchý text z následujícího fragmentu. Aspose.Slides to za vás udělá.

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