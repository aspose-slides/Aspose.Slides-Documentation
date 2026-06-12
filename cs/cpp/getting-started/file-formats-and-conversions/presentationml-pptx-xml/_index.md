---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /cs/cpp/presentationml-pptx-xml/
---
## **O PresentationML**
PresentationML je název pro rodinu formátů založených na XML pro prezentační dokumenty. Office OpenXML (OOXML) je formát založený na XML, který byl představen v aplikacích Microsoft Office 2007. Office OpenXML je kontejnerový formát pro několik specializovaných jazyků značkování založených na XML. PresentationML je jazyk značkování používaný Microsoft Office PowerPoint 2007 k ukládání jeho dokumentů. 

## **PresentationML v Aspose.Slides pro C++**
Dokumenty OOXML PresentationML jsou ve formě souborů PPTX, které jsou zkomprimované XML balíčky podle specifikací [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides pro C++ rozsáhle podporuje vytváření, čtení, manipulaci a zápis dokumentů PresentationML. Navíc je Aspose.Slides pro C++ schopno exportovat dokumenty PresentationML do různých široce používaných formátů, jako jsou PDF, TIFF a XPS. To je možné, protože Aspose.Slides pro C++ bylo navrženo s cílem komplexně zpracovávat prezentační dokumenty a PresentationML v podstatě obsahuje interní strukturu dokumentů jako zkomprimovaný XML balíček. 

## **PresentationML je otevřený, proč použít Aspose.Slides pro C++**
Vzhledem k tomu, že PresentationML je založený na XML, je poměrně snadné vytvářet aplikace pro zpracování a generování dokumentů PresentationML pomocí XML tříd, aniž byste se spolehli na knihovny třetích stran, jako je Aspose.Slides pro C++. Nicméně existuje několik výhod použití Aspose.Slides pro C++ oproti XML třídám při práci s dokumenty PresentationML. 

Specifikace OOXML je příliš rozsáhlá, sahá na několik tisíc stránek. To znamená, že pro řádné zpracování dokumentů PresentationML budete muset věnovat spoustu času a úsilí pochopení formátu těchto dokumentů. Naopak při použití Aspose.Slides pro C++ stačí použít příslušné třídy a jejich metody / vlastnosti k provádění operací, které by se zdály být poměrně složité při použití XML tříd. 

Následující jsou některé funkce, které nejsou dostupné při práci s dokumenty PresentationML pomocí XML tříd: 

- Exportovat PPT dokumenty do formátů PDF, TIFF, XPS
- Exportovat snímky v PPT dokumentech do formátu SVG
- Vykreslit snímek do libovolného formátu obrázku podporovaného C++ frameworkem
- Automatické kopírování masterů ze zdrojových prezentací pomocí funkce klonování
- Aplikace ochrany na tvary

Uveďme příklad dokumentu PresentationML, který obsahuje jediný snímek s jedním textovým polem obsahujícím text „Hello World“. Pro načtení textu pomocí XML tříd budete muset napsat program, který dokáže parsovat tento jednoduchý text z následujícího úryvku: 
## **Příklad**


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