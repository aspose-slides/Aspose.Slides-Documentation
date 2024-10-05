---
title: 異なるファイル形式と変換
type: docs
weight: 50
url: /cpp/different-file-formats-and-conversions/
---

## **Microsoft PowerPoint (PPT)**
### **PPTについて**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint)は、異なるバージョンのMicrosoft PowerPointによって作成、読み取り、操作、および書き込みが可能なプレゼンテーションドキュメントのファイル形式です。これはMicrosoftによって開発されたプレゼンテーションドキュメントのバイナリ形式です。
### **Aspose.Slides for C++におけるPPT**
Aspose.Slides for C++は、以下にリストされたソフトウェアによって作成されたPPTファイルを読み取ることができます。

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

同様に、Aspose.Slides for C++によって作成されたPPTファイルは、上記のソフトウェアセットによって読み取ることができます。
### **PPTの包括的なサポート**
Aspose.Slides for C++は、PPTドキュメントファイル形式に関連するほぼすべての機能をサポートします。これは、PPTドキュメント操作のために異なるMicrosoft PowerPointバージョンによって提供される基本的および高度な機能をカバーするだけでなく、Microsoft PowerPointによってさえサポートされていない機能も含まれています。Aspose.Slides for C++ APIライブラリを使用する主な利点は、そのような機能を扱うための使いやすさです。

PPTドキュメントファイルの作成、読み取り、および書き込みに関連する基本的なタスクに加えて、Aspose.Slides for C++によって提供されるいくつかの機能は次のとおりです：

- 他のMS Officeファイル形式をPPTドキュメント内のOLEオブジェクトとしてインポートする。
- PPTドキュメントをPDF、TIFF、XPS形式にエクスポートする。
- PPTドキュメント内のスライドをSVG形式にエクスポートする。
- スライドをC++フレームワークがサポートする任意の画像形式にレンダリングする。
- PPTドキュメント内のスライドのサイズを設定する。
- 形状上のアニメーションを管理する。
- スライドショーを管理する。
- スライド上のテキストのフォーマットを行う。
- PPTドキュメントからテキストをスキャンする。
- スライド上の表を扱う。
- クローン機能を使用してマスターを自動的にコピーする。

Aspose.Slides for C++によって生成され、Microsoft PowerPointで開かれたPPTファイル
## **PresentationML (PPTX, XML)**
### **PresentationMLについて**
PresentationMLは、プレゼンテーションドキュメント用のXMLベースの形式のファミリーの名前です。Office OpenXML (OOXML)は、Microsoft Office 2007アプリケーションで導入されたXMLベースの形式です。Office OpenXMLは、いくつかの専門化されたXMLベースのマークアップ言語のコンテナ形式です。PresentationMLは、Microsoft Office PowerPoint 2007がドキュメントを保存するために使用するマークアップ言語です。
### **Aspose.Slides for C++におけるPresentationML**
OOXML PresentationMLドキュメントは、[OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/)仕様に従ったZIP形式のXMLパッケージとしてPPTXファイルとして提供されます。Aspose.Slides for C++は、PresentationMLドキュメントの作成、読み取り、操作、および書き込みを広範にサポートしています。さらに、Aspose.Slides for C++は、PresentationMLドキュメントをPDF、TIFF、XPSなどの広く使用されている異なるドキュメント形式にエクスポートできる能力を持っています。これは、Aspose.Slides for C++がプレゼンテーションドキュメントを包括的に扱うことを目的として設計されたためであり、PresentationMLは基本的にドキュメントの内部プレゼンテーションをZIP形式のXMLパッケージとして保持します。

Aspose.Slides for C++によって生成され、Microsoft PowerPointで開かれたPPTXドキュメント

Aspose.Slides for C++によって生成されたPPTXドキュメントをZipアプリケーションで表示
### **PresentationMLはオープン、なぜAspose.Slides for C++を使用するのか**
PresentationMLはXMLベースであるため、第三者のクラスライブラリに依存せずにXMLクラスを使用してPresentationMLドキュメントの処理と生成のためのアプリケーションを構築することは十分に可能です。しかし、PresentationMLドキュメントを扱う際にXMLクラスの代わりにAspose.Slides for C++を使用するいくつかの利点があります。

OOXML仕様は数千ページにわたる非常に長いもので、PresentationMLドキュメントを適切に処理するには、その形式を理解するために多くの時間と労力を費やす必要があります。一方、Aspose.Slides for C++を使用する場合、関連するクラスとその方法/プロパティを使用するだけで、XMLクラスを介して実行すると非常に複雑に見える操作を実行できます。

以下は、XMLクラスを介してPresentationMLドキュメントを扱う際に利用できない機能のいくつかです：

- PPTドキュメントをPDF、TIFF、XPS形式にエクスポートする
- PPTドキュメント内のスライドをSVG形式にエクスポートする
- スライドをC++フレームワークがサポートする任意の画像形式にレンダリングする
- クローン機能を使用してソースプレゼンテーションからマスターを自動的にコピーする
- 形状に対する保護の適用

「Hello World」テキストを含む1つのテキストボックスを持つ単一スライドのPresentationMLドキュメントの例を見てみましょう。XMLクラスを介してテキストを読み取るには、次のフラグメントからこの単純なテキストを解析できるプログラムを書く必要があります：

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
## **PPTからPPTXへの変換**
### **変換について**
Aspose.Slidesは現在、PPTからPPTXへの変換もサポートしています。
### **変換でサポートされている機能**
Aspose.Slides for C++は、PPTドキュメントファイル形式のプレゼンテーションをPPTXファイル形式のプレゼンテーションに変換するための部分的なサポートを提供します。前述のプレゼンテーション変換機能のサポートは、Aspose.Slides for C++に新たに導入されたものであり、現時点では限られた能力しかなく、単純な形式のプレゼンテーションにのみ対応しています。Aspose.Slides for C++ APIライブラリがPPTプレゼンテーションをPPTX形式のプレゼンテーションに変換するために提供する主な利点は、望ましい目標を達成するためのAPIの使いやすさです。さらなる詳細については、この[リンク]()を参照してコードスニペットセクションに進んでください。次のセクションでは、PPT形式のプレゼンテーションをPPTX形式のプレゼンテーションに変換する際にサポートされている機能とサポートされていない機能を明示的に示します。
### **サポートされている機能**
変換中にサポートされている機能は以下のとおりです：

- マスター、レイアウト、およびスライドの構造の変換
- マスター、レイアウト、およびスライドの構造の変換
- グラフの変換
- グループ形状
- 長方形や楕円を含むオートシェイプの変換。ただし、オートシェイプに誤った調整値がある可能性があります
- カスタムジオメトリの形状。時には変換されないこともあります
- オートシェイプのテクスチャおよび画像の塗りつぶしスタイル。時には変換されないこともあります
- プレースホルダーの変換
- テキストフレームおよびテキストホルダーのテキストの変換。ただし、箇条書き、整列、タブは完全には実装されていません
### **サポートされていない機能**
変換中にサポートされていない機能は以下のとおりです：

- メモ付きスライドとしての読み取りメモがPPTXには実装されていないため、PPTにそれがある場合はPPTXとして保存できません* 線およびポリラインの変換
- 線および塗りつぶしの形式
- グラデーション塗りつぶしスタイル
- OLEフレーム、表、ビデオ、オーディオフレームなど
- アニメーションおよびその他のスライドショーのプロパティはスキップされます
  新しいまたは欠落している機能は、今後のAspose.Slides for C++のリリースで追加されます。

ソースPPTプレゼンテーション

変換されたPPTXプレゼンテーション
## **ポータブルドキュメント形式 (PDF)**
### **PDFについて**
[ポータブルドキュメント形式](https://en.wikipedia.org/wiki/PDF)は、異なる組織間での文書交換のためにAdobe Systemsによって作成されたファイル形式です。この形式の目的は、文書の内容が、表示されるプラットフォームに依存せず、その視覚的外観を表現できるようにすることでした。
### **Aspose.Slides for C++におけるPDF**
Aspose.Slides for C++にロードできる任意のプレゼンテーションドキュメントは、あなたの選択に応じて[PDF 1.5](https://en.wikipedia.org/wiki/PDF/A)または[PDF /A-1b](https://en.wikipedia.org/wiki/PDF/A)に適合するPDFドキュメントに変換できます。Aspose.Slides for C++は、プレゼンテーションドキュメントをPDFにエクスポートする際に、エクスポートされたPDFドキュメントが元のプレゼンテーションドキュメントにほぼ類似した外観になるようにします。Asposeソリューションは、PDFドキュメントに変換する際に次のプレゼンテーションドキュメントの機能をサポートしています：

- 画像、テキストボックス、およびその他の形状
- テキストとフォーマッティング
- 段落とフォーマッティング
- ハイパーリンク
- ヘッダーとフッター
- 箇条書き
- 表

あなたは、Aspose.Slides for C++コンポーネントだけを使用して、プレゼンテーションドキュメントをPDFドキュメントに直接エクスポートできます。つまり、これには他の第三者やAspose.Pdfコンポーネントは必要ありません。さらに、異なるオプションでプレゼンテーションからPDFへのエクスポートをカスタマイズすることができます。このトピックで説明されています[このトピック](/slides/cpp/converting-presentation-to-pdf/)。

Aspose.Slides for C++を介してPDFドキュメントに変換されたプレゼンテーションドキュメント
## **XMLパーサ仕様 (XPS)**
### **XPSについて**
[XMLパーサ仕様](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification)は、ページ記述言語および固定文書形式で、元々Microsoftによって開発されました。PDF同様、XPSは文書の忠実度を保持し、デバイスに依存しない文書の外観を提供するために設計された固定レイアウトドキュメント形式です。
### **Aspose.Slides for C++におけるXPS**
Aspose.Slides for C++によってロード可能な任意のプレゼンテーションドキュメントは、XPS形式に変換できます。Aspose.Slides for C++は、高忠実度のページレイアウトおよびレンダリングエンジンを使用して、固定レイアウトのXPSドキュメント形式で出力を生成します。Aspose.Slides for C++は、C++フレームワーク3.5にパッケージされているWindows Presentation Foundation (WPF)クラスに依存せずにXPSを直接生成するため、C++フレームワークのバージョン3.5よりも前のバージョンで実行されているマシンでXPSドキュメントを生成することを可能にします。Aspose.Slides for C++を使用してプレゼンテーションドキュメントをXPSドキュメントにエクスポートする方法は、[このトピック](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)で学ぶことができます。

Aspose.Slides for C++を介してXPSドキュメントに変換されたプレゼンテーションドキュメント