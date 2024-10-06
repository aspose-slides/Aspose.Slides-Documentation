---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /ja/cpp/presentationml-pptx-xml/
---

## **PresentationMLについて**
PresentationMLは、プレゼンテーション文書用のXMLベースの形式のファミリーの名前です。Office OpenXML (OOXML)は、Microsoft Office 2007アプリケーションで導入されたXMLベースの形式です。Office OpenXMLは、いくつかの専門的なXMLベースのマークアップ言語のためのコンテナ形式です。PresentationMLは、Microsoft Office PowerPoint 2007によって文書を保存するために使用されるマークアップ言語です。 
## **C++向けAspose.SlidesにおけるPresentationML**
OOXML PresentationML文書は、[OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/)仕様に従ったZIP圧縮されたXMLパッケージとしてPPTXファイルとして提供されます。C++向けAspose.Slidesは、PresentationML文書の作成、読み取り、操作、書き込みを幅広くサポートしています。さらに、C++向けAspose.Slidesは、PresentationML文書をPDF、TIFF、XPSなどの異なる一般的な文書形式にエクスポートすることができます。これは、C++向けAspose.Slidesがプレゼンテーション文書を包括的に処理することを目的に設計されているため可能です。PresentationMLは基本的に文書内部のプレゼンテーションをZIP圧縮されたXMLパッケージとして保持しています。 

## **PresentationMLはオープンです、なぜC++向けAspose.Slidesを使用するのか**
PresentationMLはXMLベースであるため、サードパーティのクラスライブラリ（例えば、C++向けAspose.Slides）に依存せずに、XMLクラスを使用してPresentationML文書を処理および生成するアプリケーションを構築することは十分に可能です。しかし、PresentationML文書を扱う際のXMLクラスに対するC++向けAspose.Slidesを使用することにはいくつかの利点があります。 

OOXML仕様は数千ページにもわたります。つまり、PresentationML文書を適切に処理するためには、そのような文書の形式を理解するために多くの時間と労力を費やさなければなりません。一方、C++向けAspose.Slidesを使用している場合、関連するクラスとそれぞれのメソッド/プロパティを使用するだけで操作を実行できます。これは、XMLクラスを介して実行される場合にはかなり複雑に見えることがあります。 

以下は、XMLクラスを介してPresentationML文書を処理する際には利用できない機能のいくつかです: 

- PPT文書をPDF、TIFF、XPS形式にエクスポート
- PPT文書内のスライドをSVG形式にエクスポート
- スライドをC++フレームワークがサポートする任意の画像形式にレンダリング
- クローン機能を使用してソースプレゼンテーションからマスターを自動的にコピー
- シェイプに対する保護の適用

「Hello World」のテキストボックスを含む単一のスライドを持つPresentationML文書の例を見てみましょう。XMLクラスを通じてテキストを読むためには、次の断片からこの単純なテキストを解析できるプログラムを書く必要があります: 
## **例**


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