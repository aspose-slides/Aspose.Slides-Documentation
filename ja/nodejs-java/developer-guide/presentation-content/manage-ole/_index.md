---
title: JavaScript を使用してプレゼンテーションの OLE を管理する
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/nodejs-java/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクト リンキング & 埋め込み
- OLE を追加
- OLE を埋め込む
- オブジェクトを追加
- オブジェクトを埋め込む
- ファイルを追加
- ファイルを埋め込む
- リンクされたオブジェクト
- リンクされたファイル
- OLE を変更
- OLE アイコン
- OLE タイトル
- OLE を抽出
- オブジェクトを抽出
- ファイルを抽出
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、PowerPoint および OpenDocument ファイルの OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新し、エクスポートできます。"
---

{{% alert color="primary" %}} 

OLE（Object Linking & Embedding）は、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みによって別のアプリケーションに配置できる Microsoft の技術です。 

{{% /alert %}} 

MS Excel で作成したチャートを考えてみましょう。そのチャートを PowerPoint のスライドに配置します。この Excel チャートは OLE オブジェクトとみなされます。 

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックするとチャートが関連付けられたアプリケーション（Excel）で開くか、オブジェクトの開閉や編集に使用するアプリケーションの選択が求められます。 
- OLE オブジェクトは実際の内容（例：チャートの内容）を表示することもあります。この場合、PowerPoint 内でチャートがアクティブになり、チャートインターフェイスが読み込まれ、PowerPoint 上でチャートのデータを変更できます。 

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) を使用すると、OLE オブジェクトをスライドに OLE オブジェクトフレーム（[OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)）として挿入できます。 

## **スライドへのOLEオブジェクトフレームの追加**

Microsoft Excel で既にチャートを作成し、Aspose.Slides for Node.js via Java を使用して OLE オブジェクトフレームとしてスライドに埋め込みたい場合、次の手順で実行できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドの参照を取得します。  
1. Excel ファイルをバイト配列として読み取ります。  
1. バイト配列と OLE オブジェクトに関するその他の情報を含む [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) をスライドに追加します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for Node.js via Java を使用して OLE オブジェクトフレームとしてスライドに追加しています。  
**Note** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) コンストラクターは、2 番目のパラメーターとして埋め込み可能なオブジェクト拡張子を受け取ります。この拡張子により、PowerPoint がファイルタイプを正しく解釈し、この OLE オブジェクトを開く適切なアプリケーションを選択できます。  
```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


### **リンクされたOLEオブジェクトフレームの追加**

Aspose.Slides for Node.js via Java を使用すると、データを埋め込まずにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) を追加できます。

以下の JavaScript コードは、リンクされた Excel ファイルを持つ [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) をスライドに追加する方法を示しています：  
```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// リンクされた Excel ファイルを使用して OLE オブジェクトフレームを追加する。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **OLEオブジェクトフレームへのアクセス**

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順で簡単に検索またはアクセスできます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成して、埋め込み OLE オブジェクトを含むプレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) シェイプにアクセスします。例では、最初のスライドに 1 つだけシェイプがある既存の PPTX を使用しています。  
4. OLE オブジェクトフレームにアクセスしたら、任意の操作を実行できます。  

以下の例では、スライドに埋め込まれた OLE オブジェクトフレーム（Excel チャートオブジェクト）とそのファイルデータにアクセスしています。  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // 埋め込まれたファイルデータを取得します。
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // 埋め込まれたファイルの拡張子を取得します。
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **リンクされたOLEオブジェクトフレームのプロパティへのアクセス**

Aspose.Slides を使用すると、リンクされた OLE オブジェクトフレームのプロパティにアクセスできます。

以下の JavaScript コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンクされたファイルへのパスを取得する方法を示しています：  
```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // OLE オブジェクトがリンクされているか確認する。
    if (oleFrame.isObjectLink()) {
        // リンクされたファイルへのフルパスを出力する。
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // 存在する場合、リンクされたファイルへの相対パスを出力する。
        // PPT プレゼンテーションのみが相対パスを保持できます。
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```


## **OLEオブジェクトデータの変更**

{{% alert color="primary" %}} 

このセクションでは、以下のコード例で [Aspose.Cells for Java](/cells/java/) を使用しています。  

{{% /alert %}}

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順でオブジェクトにアクセスしデータを変更できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成して、埋め込み OLE オブジェクトを含むプレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. OLE オブジェクトフレームシェイプにアクセスします。例では、最初のスライドに 1 つだけシェイプがある既存の PPTX を使用しています。  
4. OLE オブジェクトフレームにアクセスしたら、任意の操作を実行できます。  
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。  
6. 目的の `Worksheet` にアクセスし、データを修正します。  
7. 更新された `Workbook` をストリームに保存します。  
8. ストリームから OLE オブジェクトデータを置き換えます。  

以下の例では、スライドに埋め込まれた OLE オブジェクトフレーム（Excel チャートオブジェクト）にアクセスし、ファイルデータを変更してチャートデータを更新しています。  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE オブジェクトデータを Workbook オブジェクトとして読み取ります。
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // ワークブックのデータを変更します。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // OLE フレームオブジェクトのデータを変更します。
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **スライドへの他のファイルタイプの埋め込み**

Excel チャートに加えて、Aspose.Slides for Node.js via Java を使用すると、HTML、PDF、ZIP などの他の種類のファイルもスライドに埋め込むことができます。挿入したオブジェクトをダブルクリックすると、関連プログラムで自動的に開くか、適切なプログラムを選択するように求められます。  

以下の JavaScript コードは、HTML と ZIP をスライドに埋め込む方法を示しています：  
```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **埋め込みオブジェクトのファイルタイプ設定**

プレゼンテーションで作業する際、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされているものに差し替える必要があることがあります。Aspose.Slides for Node.js via Java を使用すると、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレームのデータや拡張子を更新できます。  

以下の JavaScript コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています：  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Change the file type to ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **埋め込みオブジェクトのアイコン画像とタイトルの設定**

OLE オブジェクトを埋め込むと、アイコン画像からなるプレビューが自動的に追加されます。このプレビューはユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビュー要素として使用したい場合は、Aspose.Slides for Node.js via Java を使用してアイコン画像とタイトルを設定できます。  

以下の JavaScript コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています：  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// プレゼンテーションのリソースに画像を追加します。
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// OLE プレビュー用にタイトルと画像を設定します。
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **OLEオブジェクトフレームのサイズ変更・再配置の防止**

リンクされた OLE オブジェクトをプレゼンテーションスライドに追加した後、PowerPoint でプレゼンテーションを開くと「リンクの更新」メッセージが表示されることがあります。「Update Links」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトのデータを更新し、オブジェクトのプレビューを再生成するため、OLE オブジェクトフレームのサイズや位置が変更されることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) クラスの `setUpdateAutomatic` メソッドに `false` を指定します：  
```javascript
oleFrame.setUpdateAutomatic(false);
```


## **埋め込みファイルの抽出**

Aspose.Slides for Node.js via Java を使用すると、スライドに OLE オブジェクトとして埋め込まれたファイルを次の手順で抽出できます。

1. 抽出対象の OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe) シェイプにアクセスします。  
3. OLE オブジェクトフレームから埋め込みファイルのデータを取得し、ディスクに書き出します。  

以下の JavaScript コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています：  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```


## **FAQ**

**OLE コンテンツは PDF/画像へエクスポートするときにレンダリングされますか？**

スライド上に表示されているものがレンダリングされます — アイコン/代替画像（プレビュー）です。「ライブ」な OLE コンテンツはレンダリング時に実行されません。必要に応じて、エクスポートされた PDF で期待通りの外観になるようプレビュー画像を自分で設定してください。  

**スライド上の OLE オブジェクトをロックして、ユーザーが PowerPoint で移動/編集できないようにするには？**

シェイプをロックします。Aspose.Slides は [シェイプレベルのロック](/slides/ja/nodejs-java/applying-protection-to-presentation/) を提供します。これは暗号化ではありませんが、誤って編集や移動することを実質的に防止します。  

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX では「相対パス」の情報は保存されません。フルパスのみが保持されます。相対パスは旧式の PPT 形式でのみ利用可能です。可搬性を考慮する場合は、信頼できる絶対パスまたはアクセス可能な URI、もしくは埋め込みを使用してください。  