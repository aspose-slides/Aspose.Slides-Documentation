---
title: シェイプレックでプレゼンテーションの編集を防止
linktitle: プレゼンテーションの編集防止
type: docs
weight: 60
url: /ja/java/applying-protection-to-presentation/
keywords:
- 編集防止
- 編集から保護
- シェイプロック
- 位置ロック
- 選択ロック
- サイズロック
- グループ化ロック
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java が PPT、PPTX、ODP ファイルのシェイプをロックまたは解除し、プレゼンテーションを保護しつつ、制御された編集と迅速な配信を可能にする方法を紹介します。"
---

## **背景**

Aspose.Slides の一般的な使用例は、Microsoft PowerPoint (PPTX) プレゼンテーションを自動化ワークフローの一部として作成、更新、保存することです。このように Aspose.Slides を使用するアプリケーションのユーザーは生成されたプレゼンテーションにアクセスできるため、編集から保護することが一般的な懸念事項です。自動生成されたプレゼンテーションが元の書式やコンテンツを保持することが重要です。

本記事では、プレゼンテーションとスライドの構造、および Aspose.Slides for Java がプレゼンテーションに保護を適用し、後で解除する方法について説明します。これにより、開発者はアプリケーションが生成したプレゼンテーションの使用方法を制御できます。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化されたシェイプ、画像フレーム、ビデオフレーム、コネクタ、その他プレゼンテーションの構築に使用される要素で構成されています。Aspose.Slides for Java では、スライド上の各要素は[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) インターフェイスを実装するオブジェクト、またはそれを継承したクラスで表されます。

PPTX の構造は複雑であるため、すべてのシェイプタイプに対して汎用ロックを使用できる PPT とは異なり、シェイプの種類ごとに異なるロックが必要です。[IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) インターフェイスは PPTX 用の汎用ロッククラスです。Aspose.Slides for Java が PPTX でサポートするロックタイプは以下のとおりです。

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) オートシェイプをロックします。  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) コネクタ シェイプをロックします。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) グラフィック オブジェクトをロックします。  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) グループ シェイプをロックします。  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) 画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) オブジェクト内のすべてのシェイプオブジェクトに対して行われる操作は、プレゼンテーション全体に適用されます。

## **保護の適用と解除**

保護を適用すると、プレゼンテーションが編集できなくなります。これはプレゼンテーションの内容を保護するための有用な手法です。

### **PPTX 図形への保護の適用**

Aspose.Slides for Java は、スライド上のシェイプを操作するための[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) インターフェイスを提供します。

前述の通り、各シェイプクラスには保護用の対応するシェイプレッククラスがあります。本記事では NoSelect、NoMove、NoResize ロックに焦点を当てます。これらのロックは、シェイプが選択（マウスクリックやその他の選択方法）できず、移動やサイズ変更もできないようにします。

以下のコードサンプルは、プレゼンテーション内のすべてのシェイプタイプに保護を適用します。
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("Sample.pptx");

// プレゼンテーション内のすべてのスライドを走査します。
for (ISlide slide : presentation.getSlides()) {

    // スライド内のすべてのシェイプを走査します。
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // シェイプをオートシェイプにキャストし、そのシェイプレックを取得します。
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // シェイプをグループシェイプにキャストし、そのシェイプレックを取得します。
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // シェイプをコネクタシェイプにキャストし、そのシェイプレックを取得します。
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // シェイプを画像フレームにキャストし、そのシェイプレックを取得します。
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// プレゼンテーションファイルを保存します。
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **保護の解除**

シェイプのロックを解除するには、適用されたロックの値を `false` に設定します。以下のコードサンプルは、ロックされたプレゼンテーションでシェイプのロックを解除する方法を示しています。
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("ProtectedSample.pptx");

// プレゼンテーション内のすべてのスライドを走査します。
for (ISlide slide : presentation.getSlides()) {

    // スライド内のすべてのシェイプを走査します。
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // シェイプをオートシェイプにキャストし、そのシェイプレックを取得します。
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // シェイプをグループシェイプにキャストし、そのシェイプレックを取得します。
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // シェイプをコネクタシェイプにキャストし、そのシェイプレックを取得します。
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // シェイプを画像フレームにキャストし、そのシェイプレックを取得します。
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// プレゼンテーションファイルを保存します。
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **結論**

Aspose.Slides では、プレゼンテーション内のシェイプを保護するためのさまざまなオプションが提供されています。個々のシェイプをロックすることも、プレゼンテーション内のすべてのシェイプを反復処理してそれぞれをロックすることで、ファイル全体を効果的に保護することもできます。ロックの値を `false` に設定すれば、保護を解除できます。

## **FAQ**

**同じプレゼンテーションで図形ロックとパスワード保護を組み合わせることはできますか？**  
はい。ロックはファイル内のオブジェクトの編集を制限し、[password protection](/slides/ja/java/password-protected-presentation/) は開くことや変更を保存することへのアクセスを制御します。これらのメカニズムは互いに補完し合い、連携して機能します。

**特定のスライドだけの編集を制限し、他のスライドには影響させないことはできますか？**  
はい。選択したスライドのシェイプにロックを適用すれば、残りのスライドは引き続き編集可能です。

**図形ロックはグループ化されたオブジェクトやコネクタにも適用されますか？**  
はい。グループ、コネクタ、グラフィック オブジェクト、その他のシェイプ種別に対して専用のロックタイプがサポートされています。