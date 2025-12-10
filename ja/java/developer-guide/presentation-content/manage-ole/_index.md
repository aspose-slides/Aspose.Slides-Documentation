---
title: Java を使用したプレゼンテーションでの OLE 管理
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/java/manage-ole/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument ファイルにおける OLE オブジェクトの管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---

{{% alert color="primary" %}} 

OLE（Object Linking &amp; Embedding）は、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みによって別のアプリケーションに配置できる Microsoft の技術です。 

{{% /alert %}} 

MS Excel で作成されたチャートを考えてみましょう。そのチャートを PowerPoint のスライドに配置します。この Excel のチャートは OLE オブジェクトと見なされます。 

- OLE オブジェクトはアイコンとして表示される場合があります。この場合、アイコンをダブルクリックすると、チャートは関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトを開く・編集するアプリケーションの選択を求められます。 
- OLE オブジェクトは実際の内容（例：チャートの内容）を表示することもあります。この場合、PowerPoint 内でチャートがアクティブになり、チャートのインターフェイスが読み込まれ、PowerPoint 上でチャートのデータを変更できます。

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) は OLE オブジェクトをスライドに OLE オブジェクト フレームとして挿入できます（[OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)）。

## **スライドへの OLE オブジェクト フレームの追加**

Microsoft Excel で既にチャートを作成し、Aspose.Slides for Java を使用して OLE オブジェクト フレームとしてスライドに埋め込みたい場合、以下の手順で実行できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. Excel ファイルをバイト配列として読み取ります。  
4. バイト配列および OLE オブジェクトに関するその他の情報を含む [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) をスライドに追加します。  
5. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。  

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for Java を使用して OLE オブジェクト フレームとしてスライドに追加しています。  
**注**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) コンストラクタは第 2 パラメータとして埋め込み可能なオブジェクト拡張子を受け取ります。この拡張子により PowerPoint はファイルタイプを正しく解釈し、この OLE オブジェクトを開く適切なアプリケーションを選択できます。  
``` java
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE オブジェクト用のデータを準備します。
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// スライドに OLE オブジェクト フレームを追加します。
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **リンクされた OLE オブジェクト フレームの追加**

Aspose.Slides for Java では、データを埋め込まずにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) を追加できます。  

以下の Java コードは、リンクされた Excel ファイルを持つ [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) をスライドに追加する方法を示しています：  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// リンクされた Excel ファイルで OLE オブジェクト フレームを追加します。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **OLE オブジェクト フレームへのアクセス**

スライドに OLE オブジェクトが既に埋め込まれている場合、以下の手順で簡単に検索またはアクセスできます。

1. 埋め込まれた OLE オブジェクトを含むプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成してロードします。  
2. インデックスを使用してスライドの参照を取得します。  
3. [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) シェイプにアクセスします。例では、最初のスライドに 1 つのシェイプしかない事前に作成した PPTX を使用しました。そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) と*キャスト*し、目的の OLE オブジェクト フレームにアクセスしました。  
4. OLE オブジェクト フレームにアクセスしたら、任意の操作を実行できます。  

以下の例では、OLE オブジェクト フレーム（スライドに埋め込まれた Excel チャートオブジェクト）とそのファイル データにアクセスしています。  
``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // 埋め込みファイルデータを取得します。
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // 埋め込みファイルの拡張子を取得します。
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **リンクされた OLE オブジェクト フレーム プロパティへのアクセス**

Aspose.Slides では、リンクされた OLE オブジェクト フレームのプロパティにアクセスできます。  

以下の Java コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンクされたファイルへのパスを取得する方法を示しています：  
```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // OLE オブジェクトがリンクされているか確認します。
    if (oleFrame.isObjectLink()) {
        // リンクされたファイルへのフルパスを出力します。
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // 存在する場合、リンクされたファイルへの相対パスを出力します。
        // 相対パスを含められるのは PPT プレゼンテーションのみです。
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```


## **OLE オブジェクト データの変更**

{{% alert color="primary" %}} 

このセクションでは、以下のコード例で [Aspose.Cells for Java](/cells/java/) を使用しています。  

{{% /alert %}}

スライドに OLE オブジェクトが既に埋め込まれている場合、以下の手順でオブジェクトにアクセスし、データを変更できます。

1. 埋め込まれた OLE オブジェクトを含むプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成してロードします。  
2. インデックスを使用してスライドの参照を取得します。  
3. OLE オブジェクト フレーム シェイプにアクセスします。例では、最初のスライドに 1 つのシェイプがある事前に作成した PPTX を使用し、そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) と*キャスト*して目的の OLE オブジェクト フレームにアクセスしました。  
4. OLE オブジェクト フレームにアクセスしたら、任意の操作を実行できます。  
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。  
6. 目的の `Worksheet` にアクセスし、データを修正します。  
7. 更新された `Workbook` をストリームに保存します。  
8. ストリームから OLE オブジェクト データを変更します。  

以下の例では、OLE オブジェクト フレーム（スライドに埋め込まれた Excel チャートオブジェクト）にアクセスし、ファイル データを変更してチャート データを更新しています。  
``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE オブジェクト データを Workbook オブジェクトとして読み取ります。
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // ワークブック データを変更します。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // OLE フレーム オブジェクト データを変更します。
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **スライドへの他のファイルタイプの埋め込み**

Excel チャートに加えて、Aspose.Slides for Java はスライドに他の種類のファイルを埋め込むことも可能です。たとえば、HTML、PDF、ZIP ファイルをオブジェクトとして挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連するプログラムで自動的に開くか、適切なプログラムの選択を促されます。  

以下の Java コードは、HTML と ZIP をスライドに埋め込む方法を示しています：  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **埋め込みオブジェクトのファイルタイプ設定**

プレゼンテーションを扱う際、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポート対象に置き換える必要がある場合があります。Aspose.Slides for Java では、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレーム データまたは拡張子を更新できます。  

以下の Java コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています：  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **埋め込みオブジェクトのアイコン画像とタイトルの設定**

OLE オブジェクトを埋め込むと、アイコン画像からなるプレビューが自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビュー要素として使用したい場合、Aspose.Slides for Java を使用してアイコン画像とタイトルを設定できます。  

以下の Java コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています：  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// プレゼンテーションのリソースに画像を追加します。
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// OLE プレビュー用にタイトルと画像を設定します。
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **OLE オブジェクト フレームのサイズ変更と位置変更を防止する**

リンクされた OLE オブジェクトをプレゼンテーション スライドに追加した後、PowerPoint でプレゼンテーションを開くと、リンクの更新を求めるメッセージが表示されることがあります。「Update Links」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトのデータを更新しプレビューを再描画するため、OLE オブジェクト フレームのサイズや位置が変更される場合があります。PowerPoint がオブジェクトのデータ更新を求めるのを防ぐには、[IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) インターフェイスの `setUpdateAutomatic` メソッドを `false` に設定します：  
```java
oleFrame.setUpdateAutomatic(false);
```


## **埋め込みファイルの抽出**

Aspose.Slides for Java を使用すると、スライドに埋め込まれたファイルを OLE オブジェクトとして以下の手順で抽出できます。

1. 抽出対象の OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe) シェイプにアクセスします。  
3. OLE オブジェクト フレームから埋め込みファイルのデータにアクセスし、ディスクに書き出します。  

以下の Java コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています：  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```


## **よくある質問**

**スライドを PDF/画像 にエクスポートするとき、OLE コンテンツはレンダリングされますか？**  
スライド上に表示されているもの、つまりアイコン/代替画像（プレビュー）がレンダリングされます。「ライブ」な OLE コンテンツはレンダリング時に実行されません。必要に応じて、エクスポートされた PDF で期待どおりの外観になるように独自のプレビュー画像を設定してください。

**PowerPoint でユーザーが OLE オブジェクトを移動・編集できないようにロックするにはどうすればよいですか？**  
シェイプをロックします。Aspose.Slides は [シェイプレベルのロック](/slides/ja/java/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤操作による編集や移動を実質的に防止できます。

**リンクされた Excel オブジェクトがプレゼンテーションを開くと「ジャンプ」したりサイズが変わったりするのはなぜですか？**  
PowerPoint はリンクされた OLE のプレビューを更新することがあります。安定した外観を得るには、[Worksheet Resizing の実践的解決策](/slides/ja/java/working-solution-for-worksheet-resizing/) に従い、フレームを範囲に合わせるか、範囲を固定フレームにスケールし、適切な代替画像を設定してください。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**  
PPTX では「相対パス」情報は保持されず、フルパスのみが保存されます。相対パスは旧来の PPT 形式でのみ利用可能です。移植性を考慮する場合は、確実な絶対パスやアクセス可能な URI、または埋め込みを推奨します。