---
title: シェイプロックでプレゼンテーションの編集を防止
linktitle: プレゼンテーションの編集防止
type: docs
weight: 10
url: /ja/cpp/applying-protection-to-presentation/
keywords:
- 編集防止
- 編集から保護
- シェイプのロック
- 位置のロック
- 選択のロック
- サイズのロック
- グループ化のロック
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ が PPT、PPTX、ODP ファイル内のシェイプをロックまたはロック解除する方法を学び、プレゼンテーションを保護しつつ、制御された編集と高速な配信を可能にします。"
---

## **背景**

Aspose.Slides の一般的な使用例は、Microsoft PowerPoint (PPTX) プレゼンテーションを自動化されたワークフローの一部として作成、更新、保存することです。  
このように Aspose.Slides を使用するアプリケーションのユーザーは生成されたプレゼンテーションにアクセスできるため、編集から保護することが一般的な懸念事項です。  
自動生成されたプレゼンテーションが元の書式と内容を保持することが重要です。

この記事では、プレゼンテーションとスライドの構造、および Aspose.Slides for C++ がプレゼンテーションに保護を適用し、後で解除する方法について説明します。開発者は、アプリケーションが生成するプレゼンテーションの使用方法を制御できるようになります。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化シェイプ、画像フレーム、ビデオフレーム、コネクタ、その他プレゼンテーションを構成する要素で構成されています。  
Aspose.Slides for C++ では、スライド上の各要素は[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) インターフェイスを実装するオブジェクト、またはそのクラスを継承したオブジェクトとして表されます。

PPTX の構造は複雑であるため、すべての形状タイプに汎用ロックを使用できる PPT とは異なり、形状タイプごとに異なるロックが必要です。  
[IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) インターフェイスは PPTX 用の汎用ロッククラスです。  
Aspose.Slides for C++ が PPTX でサポートするロックタイプは以下のとおりです。

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) はオートシェイプをロックします。  
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) はコネクタ形状をロックします。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) はグラフィックオブジェクトをロックします。  
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) はグループシェイプをロックします。  
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) は画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) オブジェクト内のすべてのシェイプオブジェクトに対して実行された操作は、プレゼンテーション全体に適用されます。

## **保護の適用と解除**

保護を適用することで、プレゼンテーションが編集できないようにします。これはプレゼンテーションの内容を保護する便利な手法です。

### **PPTX シェイプへの保護の適用**

Aspose.Slides for C++ はスライド上のシェイプを操作するために[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) インターフェイスを提供します。

前述のとおり、各シェイプクラスには保護用のシェイプロッククラスが関連付けられています。この記事では NoSelect、NoMove、NoResize ロックに焦点を当てます。これらのロックは、シェイプが選択（マウスクリックやその他の選択方法）できず、移動やサイズ変更もできないようにします。

以下のコードサンプルは、プレゼンテーション内のすべてのシェイプタイプに保護を適用します。
```cpp
// PPTX ファイルを表す Presentation クラスをインスタンス化します。
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// プレゼンテーション内のすべてのスライドを走査します。
for (auto&& slide : presentation->get_Slides())	{

	// スライド内のすべてのシェイプを走査します。
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// シェイプをオートシェイプにキャストし、シェイプロックを取得します。
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// シェイプをグループシェイプにキャストし、シェイプロックを取得します。
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// シェイプをコネクタシェイプにキャストし、シェイプロックを取得します。
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// シェイプを画像フレームにキャストし、シェイプロックを取得します。
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// プレゼンテーションファイルを保存します。
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


### **保護の解除**

シェイプのロックを解除するには、適用されたロックの値を `false` に設定します。以下のコードサンプルは、ロックされたプレゼンテーション内のシェイプのロックを解除する方法を示しています。
```cpp
// PPTX ファイルを表す Presentation クラスをインスタンス化します。
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// プレゼンテーション内のすべてのスライドを走査します。
for (auto&& slide : presentation->get_Slides())	{

	// スライド内のすべてのシェイプを走査します。
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// シェイプをオートシェイプにキャストし、シェイプロックを取得します。
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// シェイプをグループシェイプにキャストし、シェイプロックを取得します。
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// シェイプをコネクタシェイプにキャストし、シェイプロックを取得します。
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// シェイプを画像フレームにキャストし、シェイプロックを取得します。
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// プレゼンテーションファイルを保存します。
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **結論**

Aspose.Slides では、プレゼンテーション内のシェイプを保護するためのさまざまなオプションが提供されています。個々のシェイプをロックしたり、プレゼンテーション内のすべてのシェイプを反復処理してそれぞれをロックすることで、ファイル全体を効果的に保護できます。ロックの値を `false` に設定することで保護を解除できます。

## **よくある質問**

**同じプレゼンテーションでシェイプロックとパスワード保護を組み合わせることはできますか？**

はい。ロックはファイル内のオブジェクトの編集を制限し、[パスワード保護](/slides/ja/cpp/password-protected-presentation/) は開く際や変更を保存する際のアクセスを制御します。これらの仕組みは相互補完的で、連携して機能します。

**特定のスライドだけ編集を制限し、他のスライドには影響させずにできますか？**

はい。選択したスライドのシェイプにロックを適用すれば、他のスライドは引き続き編集可能です。

**シェイプロックはグループ化オブジェクトやコネクタにも適用されますか？**

はい。グループ、コネクタ、グラフィックオブジェクト、その他のシェイプ種別に対して専用のロックタイプがサポートされています。