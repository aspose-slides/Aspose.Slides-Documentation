---  
title: PresentationML (PPTX, XML)  
type: docs  
weight: 20  
url: /ja/java/presentationml-pptx-xml/  
---  

{{% alert color="primary" %}}  

PresentationMLは、プレゼンテーション文書のためのXMLベースのフォーマットのファミリーの名称です。Office OpenXML（OOXML）は、Microsoft Office 2007アプリケーションで導入されたXMLベースのフォーマットです。Office OpenXMLは、いくつかの専門的なXMLベースのマークアップ言語のコンテナフォーマットです。PresentationMLは、Microsoft Office PowerPoint 2007が文書を保存するために使用するマークアップ言語です。  

{{% /alert %}}  

## **Aspose.Slides for JavaにおけるPresentationML**  
OOXML PresentationML文書は、[OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/)仕様に従ったPPTXファイルとして提供されます。Aspose.Slides for Javaは、PresentationML文書の作成、読み取り、操作、および書き込みを広範囲にサポートしています。さらに、Aspose.Slides for Javaは、PresentationML文書をPDFのような広く使用されている文書形式にエクスポートすることができます。これは、Aspose.Slides for Javaがプレゼンテーション文書を包括的に扱うことを目的として設計されており、PresentationMLが基本的に文書の内部プレゼンテーションをZIP形式のXMLパッケージとして保持しているためです。  

**Aspose.Slides for Javaによって生成され、Microsoft PowerPointで開かれたPPTX文書**  

![todo:image_alt_text](presentationml-pptx-xml_1.png)  

**ZIP内のAspose.Slides for Javaによって生成された同じPPTX文書の表示**  

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)  

## **PresentationMLはオープンです。なぜAspose.Slides for Javaを使用するのですか？**  
PresentationMLはXMLに基づいているため、Aspose.Slides for Javaのようなサードパーティのクラスライブラリに依存せず、XMLクラスを使用してPresentationML文書を処理し生成するアプリケーションを構築することは可能です。しかし、PresentationML文書を扱う際にXMLクラスよりもAspose.Slides for Javaを使用することで得られるいくつかの利点があります。  

OOXML仕様は数千ページにわたるため、PresentationML文書を適切に扱うには、フォーマットを理解するために多くの時間と労力を費やす必要があります。一方で、Aspose.Slides for Javaを使用すれば、クラスとそのメソッドやプロパティを使用して操作を実行することができ、XMLクラスを使用した場合には複雑に見える場合でも簡単に行うことができます。  

Aspose.Slidesが提供する機能の一部は、XMLクラスを通じてPresentationML文書を扱う際には利用できません：  

- PPT文書をPDF形式にエクスポートする。  
- スライドをJavaフレームワークがサポートする任意の画像形式にレンダリングする。  
- クローン機能を使用してソースプレゼンテーションからマスターを自動的にコピーする。  
- 形状に保護を適用する。  

以下は、「Hello World」というテキストボックスを含む単一スライドのPresentationML文書の例です。XMLクラスを使用してテキストを読み取るには、次のフラグメントからこの単純なテキストを解析できるプログラムを書く必要があります。Aspose.Slidesはそれを代わりに行います。  

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