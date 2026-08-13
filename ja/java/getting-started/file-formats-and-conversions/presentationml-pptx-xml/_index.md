---
title: PresentationML（PPTX、XML）
type: docs
weight: 20
url: /ja/java/presentationml-pptx-xml/
---
{{% alert color="info" %}} 

PresentationML は、プレゼンテーション文書用の XML ベースのフォーマット群の名称です。Office OpenXML（OOXML）は、Microsoft Office 2007 アプリケーションで導入された XML ベースのフォーマットです。Office OpenXML は、複数の専門的な XML ベースのマークアップ言語のコンテナ形式です。PresentationML は、Microsoft Office PowerPoint 2007 が文書を保存するために使用するマークアップ言語です。

{{% /alert %}} 

## **Aspose.Slides for Java の PresentationML**

OOXML PresentationML ドキュメントは PPTX ファイルとして提供され、[OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) 仕様に従った圧縮 XML パッケージです。Aspose.Slides for Java は、PresentationML ドキュメントの作成、読み取り、操作、書き込みを広範にサポートします。さらに、Aspose.Slides for Java は、PresentationML ドキュメントを PDF のような広く使用されているドキュメント形式にエクスポートすることができます。これは、Aspose.Slides for Java がプレゼンテーションドキュメントを包括的に処理することを目的として設計されており、PresentationML が基本的に文書の内部プレゼンテーションを圧縮 XML パッケージとして保持しているためです。

**Aspose.Slides for Java で生成され Microsoft PowerPoint で開かれた PPTX ドキュメント** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Aspose.Slides for Java で生成された同じ PPTX ドキュメントを ZIP で表示** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML はオープン、なぜ Aspose.Slides for Java を使用すべきか？**
PresentationML は XML ベースであるため、Aspose.Slides for Java のようなサードパーティのクラスライブラリに依存せずに XML クラスを使用して PresentationML ドキュメントを処理・生成するアプリケーションを構築することは十分に可能です。ただし、PresentationML ドキュメントを扱う際に XML クラスよりも Aspose.Slides for Java を使用することにはいくつかの利点があります。

OOXML 仕様は数千ページにわたるため、PresentationML ドキュメントを適切に扱うにはフォーマットを理解するために多くの時間と労力が必要です。一方、Aspose.Slides for Java を使用すれば、クラスとそのメソッドやプロパティを利用するだけで、XML クラスで行うと複雑に見える操作を簡単に実行できます。

XML クラスで PresentationML ドキュメントを扱う場合には利用できない、Aspose.Slides が提供する機能もいくつかあります。

- PPT ドキュメントを PDF 形式にエクスポートする。
- Java フレームワークがサポートする任意の画像形式にスライドをレンダリングする。
- クローン機能を使用して、ソースプレゼンテーションからマスターを自動的にコピーする。
- シェイプに保護を適用する。

以下は、テキストボックスに “Hello World” という文字列が含まれる 1 枚のスライドを持つ PresentationML ドキュメントの例です。XML クラスを使用してテキストを読み取るには、次のフラグメントからこの単純なテキストを解析するプログラムを書く必要があります。Aspose.Slides がそれを行ってくれます。

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