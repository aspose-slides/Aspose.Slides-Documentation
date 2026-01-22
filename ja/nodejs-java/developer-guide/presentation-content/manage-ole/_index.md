---
title: JavaScript を使用したプレゼンテーションでの OLE 管理
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/nodejs-java/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクト リンキング & 埋め込み
- OLE の追加
- OLE の埋め込み
- オブジェクトの追加
- オブジェクトの埋め込み
- ファイルの追加
- ファイルの埋め込み
- リンクされたオブジェクト
- リンクされたファイル
- OLE の変更
- OLE アイコン
- OLE タイトル
- OLE の抽出
- オブジェクトの抽出
- ファイルの抽出
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument ファイルの OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---

{{% alert color="primary" %}} 

OLE（Object Linking & Embedding）は、1 つのアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みによって別のアプリケーションに配置できる Microsoft の技術です。 

{{% /alert %}} 

MS Excel で作成したチャートを PowerPoint のスライドに配置したとします。その Excel チャートは OLE オブジェクトとみなされます。 

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックするとチャートは関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトの開閉や編集のためにアプリケーションを選択するよう求められます。 
- OLE オブジェクトはチャート本体の内容など実際のデータを表示することがあります。この場合、チャートは PowerPoint 内でアクティブ化され、インターフェイスが読み込まれ、PowerPoint 上でチャートのデータを変更できるようになります。

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) を使用すると、スライドに OLE オブジェクトを OLE オブジェクトフレーム（[OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)）として挿入できます。

## **スライドへのOLEオブジェクトフレームの追加**

Excel で作成したチャートを Aspose.Slides for Node.js via Java を使用して OLE オブジェクトフレームとしてスライドに埋め込む手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。 
1. インデックスを使用してスライドへの参照を取得します。 
1. Excel ファイルをバイト配列として読み取ります。 
1. バイト配列および OLE オブジェクトに関するその他の情報を含む [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) をスライドに追加します。 
1. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。 

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for Node.js via Java を使用して OLE オブジェクトフレームとしてスライドに追加しています。  
**注意** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) コンストラクタは、2 番目のパラメータとして埋め込むオブジェクトの拡張子を受け取ります。この拡張子により、PowerPoint はファイル種別を正しく解釈し、適切なアプリケーションで OLE オブジェクトを開くことができます。  
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

以下の JavaScript コードは、リンクされた Excel ファイルを持つ [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) をスライドに追加する方法を示しています。  
```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// リンクされた Excel ファイルを使用して OLE オブジェクトフレームを追加します。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **OLEオブジェクトフレームへのアクセス**

スライドに既に埋め込まれた OLE オブジェクトがある場合、次の手順で簡単に取得またはアクセスできます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションをロードします。 
2. インデックスを使用してスライドへの参照を取得します。 
3. [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) シェイプにアクセスします。例では、1 枚目のスライドに 1 つだけシェイプがある PPTX を使用しました。 
4. OLE オブジェクトフレームにアクセスしたら、任意の操作を実行できます。 

以下の例では、スライドに埋め込まれた Excel チャートオブジェクト（OLE オブジェクトフレーム）とそのファイルデータにアクセスしています。  
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


### **リンクされたOLEオブジェクトフレームプロパティへのアクセス**

Aspose.Slides では、リンクされた OLE オブジェクトフレームのプロパティにアクセスできます。

以下の JavaScript コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンク先ファイルへのパスを取得する方法を示します。  
```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // OLE オブジェクトがリンクされているか確認します。
    if (oleFrame.isObjectLink()) {
        // リンクされたファイルへのフルパスを出力します。
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // 存在する場合、リンクされたファイルへの相対パスを出力します。
        // 相対パスは PPT プレゼンテーションにのみ含まれます。
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

スライドに既に埋め込まれた OLE オブジェクトがある場合、次の手順でオブジェクトにアクセスし、データを変更できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションをロードします。 
2. インデックスを使用してスライドへの参照を取得します。 
3. OLE オブジェクトフレーム シェイプにアクセスします。例では、1 枚目のスライドに 1 つだけシェイプがある PPTX を使用しました。 
4. OLE オブジェクトフレームにアクセスしたら、任意の操作を実行できます。 
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。 
6. 対象の `Worksheet` にアクセスし、データを修正します。 
7. 更新された `Workbook` をストリームに保存します。 
8. ストリームから OLE オブジェクトデータを変更します。 

以下の例では、スライドに埋め込まれた Excel チャートオブジェクト（OLE オブジェクトフレーム）にアクセスし、そのファイルデータを変更してチャートデータを更新しています。  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE オブジェクト データを Workbook オブジェクトとして読み取ります。
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // ワークブック データを変更します。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // OLE フレーム オブジェクト データを変更します。
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **スライドへのその他のファイル種別の埋め込み**

Excel チャートに加えて、Aspose.Slides for Node.js via Java を使用すると、HTML、PDF、ZIP などの他のファイル種別もオブジェクトとしてスライドに埋め込めます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連プログラムで自動的に開くか、適切なプログラムを選択するよう求められます。

以下の JavaScript コードは、HTML と ZIP をスライドに埋め込む方法を示しています。  
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


## **埋め込みオブジェクトのファイル種別設定**

プレゼンテーションを扱う際、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポート対象に置き換える必要がある場合があります。Aspose.Slides for Node.js via Java を使用すると、埋め込みオブジェクトのファイル種別を設定でき、OLE フレームのデータや拡張子を更新できます。

以下の JavaScript コードは、埋め込まれた OLE オブジェクトのファイル種別を `zip` に設定する方法を示しています。  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// ファイルタイプを ZIP に変更します。
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **埋め込みオブジェクトのアイコン画像とタイトル設定**

OLE オブジェクトを埋め込むと、自動的にアイコン画像を含むプレビューが追加されます。このプレビューはユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビュー要素として使用したい場合、Aspose.Slides for Node.js via Java を使用してアイコン画像とタイトルを設定できます。

以下の JavaScript コードは、埋め込まれたオブジェクトのアイコン画像とタイトルを設定する方法を示しています。  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// プレゼンテーションのリソースに画像を追加します。
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **OLEオブジェクトフレームのサイズ変更と再配置の防止**

リンクされた OLE オブジェクトをスライドに追加した後、PowerPoint でプレゼンテーションを開くと「リンクの更新」メッセージが表示されることがあります。**[Update Links]** ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトからデータを取得しプレビューを更新するため、OLE オブジェクトフレームのサイズや位置が変更されることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、`setUpdateAutomatic` メソッドを `false` に設定します。  
```javascript
oleFrame.setUpdateAutomatic(false);
```


## **埋め込みファイルの抽出**

Aspose.Slides for Node.js via Java を使用すると、スライドに OLE オブジェクトとして埋め込まれたファイルを次の手順で抽出できます。

1. 抽出対象の OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。 
2. プレゼンテーション内のすべてのシェイプをループし、[OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe) シェイプにアクセスします。 
3. OLE オブジェクトフレームから埋め込まれたファイルのデータにアクセスし、ディスクに書き出します。 

以下の JavaScript コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています。  
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

**OLE コンテンツはスライドを PDF／画像にエクスポートする際にレンダリングされますか？**

スライド上に表示されているものがレンダリングされます――アイコン／代替画像（プレビュー）です。「ライブ」な OLE コンテンツはレンダリング時には実行されません。必要に応じて、期待通りの外観になるよう独自のプレビュー画像を設定してください。

**OLE オブジェクトをスライド上でロックし、PowerPoint でユーザーが移動／編集できないようにするには？**

シェイプのロック機能を使用します。Aspose.Slides はシェイプ単位のロックを提供しており、暗号化ではありませんが、誤操作や移動を実質的に防止できます。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX では「相対パス」情報は保持されず、フルパスのみが保存されます。相対パスは旧形式の PPT にのみ存在します。可搬性を考慮する場合は、信頼できる絶対パス／アクセス可能な URI を使用するか、埋め込みを検討してください。