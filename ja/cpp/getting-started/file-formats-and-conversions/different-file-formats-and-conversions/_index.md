---
title: さまざまなファイル形式と変換
type: docs
weight: 50
url: /ja/cpp/different-file-formats-and-conversions/
---

## **Microsoft PowerPoint (PPT)**
### **PPT の概要**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint)は、Microsoft PowerPoint のさまざまなバージョンで作成、読み取り、操作、書き込みが可能なプレゼンテーション ドキュメント ファイル形式です。これは、Microsoft が開発したプレゼンテーション ドキュメント用のバイナリ形式です。
### **Aspose.Slides for C++ における PPT**
Aspose.Slides for C++ は、以下のソフトウェアで作成された PPT ファイルを読み取ることができます。

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

同様に、Aspose.Slides for C++ で作成された PPT ファイルは、上記のソフトウェアで読み取ることができます。
### **PPT の包括的サポート**
Aspose.Slides for C++ は、PPT ドキュメント ファイル形式に関連するほぼすべての機能をサポートします。これは、さまざまな Microsoft PowerPoint バージョンが提供する基本/高度な機能だけでなく、Microsoft PowerPoint でもサポートされていない機能も含みます。Aspose.Slides for C++ API ライブラリを使用する主な利点は、これらの機能を簡単に扱えることです。

基本的な作成、読み取り、書き込みタスクに加えて、Aspose.Slides for C++ が提供する機能には次のものがあります。

- 他の MS Office ファイル形式を PPT ドキュメント内の OLE オブジェクトとしてインポート
- PPT ドキュメントを PDF、TIFF、XPS 形式にエクスポート
- PPT ドキュメント内のスライドを SVG 形式にエクスポート
- スライドを C++ Framework がサポートする任意の画像形式にレンダリング
- PPT ドキュメント内のスライドサイズを設定
- シェイプのアニメーションを管理
- スライドショーを管理
- スライド上のテキスト書式設定
- PPT ドキュメントからテキストをスキャン
- スライド上のテーブルを操作
- クローン機能を使用したマスターの自動コピー

Aspose.Slides for C++ で生成され、Microsoft PowerPoint で開かれた PPT ファイル
## **PresentationML (PPTX, XML)**
### **PresentationML の概要**
PresentationML は、プレゼンテーション ドキュメント用の XML ベースのフォーマット ファミリーの名前です。Office OpenXML (OOXML) は、Microsoft Office 2007 アプリケーションで導入された XML ベースの形式です。Office OpenXML は、複数の専門的 XML マークアップ言語のコンテナ形式であり、PresentationML は Microsoft Office PowerPoint 2007 がドキュメントを保存するために使用するマークアップ言語です。
### **Aspose.Slides for C++ における PresentationML**
OOXML PresentationML ドキュメントは、[OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) 仕様に従った ZIP 形式の XML パッケージである PPTX ファイルとして提供されます。Aspose.Slides for C++ は、PresentationML ドキュメントの作成、読み取り、操作、書き込みを広範にサポートします。さらに、Aspose.Slides for C++ は、PresentationML ドキュメントを PDF、TIFF、XPS などの広く使われている文書形式にエクスポートすることができます。これは、Aspose.Slides for C++ がプレゼンテーション ドキュメントを包括的に処理することを目的に設計されており、PresentationML が内部的に ZIP 形式の XML パッケージとしてプレゼンテーションを保持しているため実現できます。

Aspose.Slides for C++ で生成され、Microsoft PowerPoint で開かれた PPTX ドキュメント

Aspose.Slides for C++ によって Zip アプリケーションで表示された PPTX ドキュメント
### **PresentationML はオープンです。なぜ Aspose.Slides for C++ を使用するのか**
PresentationML は XML ベースであるため、XML クラスだけを使用してサードパーティのライブラリ（Aspose.Slides for C++ など）に依存せずに PresentationML ドキュメントの処理・生成アプリケーションを構築することは可能です。しかし、PresentationML ドキュメントを扱う際に XML クラスだけでなく Aspose.Slides for C++ を使用する方が多くの利点があります。

OOXML 仕様は数千ページに及ぶ非常に長大なものです。つまり、PresentationML ドキュメントを正しく扱うには、フォーマットの詳細を理解するために多大な時間と労力が必要です。一方、Aspose.Slides for C++ を使用すれば、関連クラスとそのメソッド／プロパティを呼び出すだけで、XML クラスで実装すると複雑になる操作を簡単に実行できます。

XML クラスだけで PresentationML ドキュメントを扱う場合に利用できない機能の例は次のとおりです。

- PPT ドキュメントを PDF、TIFF、XPS 形式にエクスポート
- PPT ドキュメント内のスライドを SVG 形式にエクスポート
- スライドを C++ Framework がサポートする任意の画像形式にレンダリング
- クローン機能を使用したソース プレゼンテーションからのマスター自動コピー
- シェイプへの保護設定

例として、単一スライドに「Hello World」テキスト ボックスが含まれる PresentationML ドキュメントを考えます。このテキストを XML クラスで取得するには、次のフラグメントからテキストを解析するプログラムを書く必要があります。
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

## **PPT から PPTX への変換**
### **変換の概要**
Aspose.Slides は現在、PPT から PPTX への変換もサポートしています。
### **変換でサポートされる機能**
Aspose.Slides for C++ は、PPT ドキュメント形式のプレゼンテーションを PPTX 形式のプレゼンテーションに変換する機能の一部をサポートします。このプレゼンテーション変換機能は Aspose.Slides for C++ に最近追加されたため、現時点では機能が制限されており、シンプルなプレゼンテーションのみで動作します。PPT プレゼンテーションを PPTX 形式に変換する際の主な利点は、目的を達成するために API を簡単に使用できることです。詳細は this[link]() のコード スニペット セクションをご覧ください。以下のセクションでは、PPT 形式プレゼンテーションを PPTX 形式プレゼンテーションに変換する際にサポートされる機能とサポートされない機能を明確に示しています。
### **サポートされる機能**
変換中にサポートされる機能は次のとおりです。

- マスタ、レイアウト、スライドの構造変換
- マスタ、レイアウト、スライドの構造変換
- グラフの変換
- グループ シェイプ
- 矩形や楕円などの自動シェイプの変換。ただし、調整値が正しくない場合があります
- カスタム ジオメトリを持つシェイプ。一部は変換されないことがあります
- テクスチャと画像の塗りつぶしスタイル。一部は変換されないことがあります
- プレースホルダーの変換
- テキスト フレームおよびテキスト ホルダー内のテキストの変換。ただし、箇条書き、配置、タブは完全には実装されていません
### **サポートされない機能**
変換中にサポートされない機能は次のとおりです。

- ノート付きスライド（PPTX ではノートの読み取りが実装されていません）。PPT にノートがある場合、まだ PPTX として保存できません
- 線とポリラインの変換
- 線および塗りつぶし形式
- グラデーション塗りつぶしスタイル
- OLE フレーム、テーブル、ビデオ・オーディオ フレームなど
- アニメーションやその他のスライドショー プロパティはスキップされます

新機能や未実装機能は、今後の Aspose.Slides for C++ のリリースで追加されます。

元の PPT プレゼンテーション

変換された PPTX プレゼンテーション
## **Portable Document Format (PDF)**
### **PDF の概要**
[Portable Document Format](https://en.wikipedia.org/wiki/PDF) は、Adobe System が異なる組織間で文書をやり取りするために作成したファイル形式です。この形式の目的は、文書の内容がプラットフォームに依存せずに視覚的外観を保持できるようにすることです。
### **Aspose.Slides for C++ における PDF**
Aspose.Slides for C++ に読み込むことのできる任意のプレゼンテーション ドキュメントは、[PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) または [PDF /A-1b](https://en.wikipedia.org/wiki/PDF/A) に準拠した PDF ドキュメントに変換できます。Aspose.Slides for C++ は、変換された PDF ドキュメントが元のプレゼンテーション ドキュメントとほぼ同一に見えるようエクスポートします。Aspose のソリューションは、PDF 変換時にプレゼンテーション ドキュメントの次の機能をサポートします。

- 画像、テキスト ボックス、その他のシェイプ
- テキストと書式設定
- 段落と書式設定
- ハイパーリンク
- ヘッダーとフッター
- 箇条書き
- テーブル

Aspose.Slides for C++ コンポーネントだけでプレゼンテーション ドキュメントを PDF に直接エクスポートできます。他のサードパーティ製品や Aspose.Pdf コンポーネントは必要ありません。さらに、エクスポートは [this topic](/slides/ja/cpp/convert-powerpoint-to-pdf/) で説明されているように、さまざまなオプションでカスタマイズ可能です。

Aspose.Slides for C++ を介して PDF に変換されたプレゼンテーション ドキュメント
## **XML Parser Specification (XPS)**
### **XPS の概要**
[XML Parser Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) は、Microsoft が最初に開発したページ記述言語および固定文書形式です。PDF と同様に、XPS は文書の忠実度を保持し、デバイスに依存しない外観を提供する固定レイアウト文書形式です。
### **Aspose.Slides for C++ における XPS**
Aspose.Slides for C++ に読み込むことのできる任意のプレゼンテーション ドキュメントは、XPS 形式に変換できます。Aspose.Slides for C++ は高忠実度のページレイアウトおよびレンダリング エンジンを使用して、固定レイアウトの XPS ドキュメント形式で出力します。特筆すべきは、Aspose.Slides for C++ が Windows Presentation Foundation (WPF) クラスに依存せずに直接 XPS を生成できるため、C++ Framework 3.5 以前のバージョンでも XPS ドキュメントを生成できることです。XPS へのエクスポート方法は [this topic](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/) を参照してください。

Aspose.Slides for C++ を介して XPS に変換されたプレゼンテーション ドキュメント