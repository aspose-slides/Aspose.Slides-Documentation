---
title: PresentationML (PPTX, XML) (Historické)
type: docs
weight: 20
url: /cs/java/presentationml-pptx-xml/
keywords:
- PresentationML
- PPTX
- Office Open XML
- historické
- Java
- Aspose.Slides
description: "Historické: starší přehled formátu PresentationML (PPTX) v Aspose.Slides pro Java, zachovaný pro existující odkazy. Aktuální seznam podporovaných formátů je v sekci Podporované formáty souborů."
---
{{% alert color="info" title="Poznámka" %}}

Toto je historická stránka, zachovaná pro existující odkazy. Nepopisuje aktuální verzi Aspose.Slides for Java. Pro formáty, které Aspose.Slides for Java načítá, importuje, ukládá a vykresluje, a pro API pro každý z nich, viz [Podporované formáty souborů](/slides/cs/java/supported-file-formats/). Pro srovnání PPTX s PPT viz [Porozumění rozdílu: PPT vs PPTX](/slides/cs/java/ppt-vs-pptx/).

{{% /alert %}}

{{% alert color="info" title="Poznámka" %}}

PresentationML je název pro rodinu formátů založených na XML pro prezentační dokumenty. Office OpenXML (OOXML) je formát založený na XML, který byl představen v aplikacích Microsoft Office 2007. Office OpenXML je kontejnerový formát pro několik specializovaných jazyků značkování založených na XML. PresentationML je jazyk značkování používaný v Microsoft Office PowerPoint 2007 k ukládání dokumentů.

{{% /alert %}}

## **PresentationML v Aspose.Slides for Java**
Dokumenty OOXML PresentationML se vyskytují jako soubory PPTX, zabalené XML balíčky, které splňují specifikaci [OOXML ECMA-376](https://ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for Java rozsáhle podporuje vytváření, čtení, manipulaci a zápis dokumentů PresentationML. Navíc je Aspose.Slides for Java schopno exportovat dokumenty PresentationML do široce používaného formátu dokumentu, jako je PDF. To je možné, protože Aspose.Slides for Java bylo navrženo s cílem komplexně zpracovávat prezentační dokumenty a PresentationML v podstatě obsahuje interní prezentaci dokumentů jako zabalený XML balíček.

**PPTX dokument vygenerovaný pomocí Aspose.Slides for Java a otevřený v Microsoft PowerPoint**

![PPTX dokument vygenerovaný pomocí Aspose.Slides for Java a otevřený v Microsoft PowerPoint](presentationml-pptx-xml_1.png)

**Zobrazení stejného PPTX dokumentu vygenerovaného pomocí Aspose.Slides for Java jako ZIP**

![Stejný PPTX dokument zobrazený jako ZIP balíček](presentationml-pptx-xml_2.jpg)

## **PresentationML je otevřený, proč používat Aspose.Slides for Java?**
Protože PresentationML je založený na XML, je naprosto možné vytvářet aplikace pro zpracování a generování dokumentů PresentationML pomocí XML tříd, aniž byste se spolehli na knihovnu třetí strany, jako je Aspose.Slides for Java. Nicméně existuje několik výhod používání Aspose.Slides for Java oproti XML třídám při práci s dokumenty PresentationML.

Specifikace OOXML má několik tisíc stránek, takže pro řádné zpracování dokumentů PresentationML musíte věnovat spoustu času a úsilí pochopení formátu. Na druhou stranu s Aspose.Slides for Java stačí použít třídy a jejich metody a vlastnosti k provádění operací, které by se zdály složité při použití XML tříd.

Některé funkce, které Aspose.Slides nabízí, nejsou vůbec k dispozici při práci s dokumenty PresentationML pomocí XML tříd:

- Exportovat PPT dokumenty do formátu PDF.
- Vykreslit snímek do jakéhokoli formátu obrázku podporovaného frameworkem Java.
- Automaticky kopírovat master snímky ze zdrojové prezentace pomocí funkce klonování.
- Použít ochranu na tvary.

Níže je příklad dokumentu PresentationML s jedním snímkem obsahujícím textové pole s textem “Hello World”. Pro načtení textu pomocí XML tříd musíte napsat program, který dokáže tento jednoduchý text z následujícího fragmentu parsovat. Aspose.Slides to za vás udělá.

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