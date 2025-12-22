---
title: Android でプレゼンテーションからスライドを削除する
linktitle: スライドを削除
type: docs
weight: 30
url: /ja/androidjava/remove-slide-from-presentation/
keywords:
- スライドを削除
- スライドを削除
- 未使用スライドを削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、PowerPoint および OpenDocument のプレゼンテーションからスライドを簡単に削除できます。分かりやすい Java コード例を取得し、ワークフローを向上させましょう。"
---

スライド（またはその内容）が不要になった場合は削除できます。Aspose.Slides は、プレゼンテーション内のすべてのスライドのリポジトリである[ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/)をカプセル化した[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスを提供します。既知の[ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/)オブジェクトに対して参照またはインデックスのポインタを使用すると、削除したいスライドを指定できます。

## **参照によるスライドの削除**

1. Presentation クラスのインスタンスを作成します。
1. 削除したいスライドの ID またはインデックスを使用して、その参照を取得します。
1. 参照したスライドをプレゼンテーションから削除します。
1. 変更されたプレゼンテーションを保存します。 

この Java コードは、参照を使用してスライドを削除する方法を示します:
```java
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化
Presentation pres = new Presentation("demo.pptx");
try {
    // スライドコレクション内のインデックスを使ってスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 参照を使ってスライドを削除
    pres.getSlides().remove(slide);
    
    // 変更されたプレゼンテーションを保存
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **インデックスによるスライドの削除**

1. Presentation クラスのインスタンスを作成します。
1. インデックス位置を使用して、プレゼンテーションからスライドを削除します。
1. 変更されたプレゼンテーションを保存します。 

この Java コードは、インデックスを使用してスライドを削除する方法を示します:
```java
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化
Presentation pres = new Presentation("demo.pptx");
try {
    // スライドインデックスを使用してスライドを削除
    pres.getSlides().removeAt(0);
    
    // 変更されたプレゼンテーションを保存
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **未使用のレイアウトスライドの削除**

Aspose.Slides は、不要で未使用のレイアウトスライドを削除できるように、[Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) クラスの[removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) メソッドを提供します。この Java コードは、PowerPoint プレゼンテーションからレイアウトスライドを削除する方法を示します:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **未使用のマスタースライドの削除**

Aspose.Slides は、不要で未使用のマスタースライドを削除できるように、[Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) クラスの[removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) メソッドを提供します。この Java コードは、PowerPoint プレゼンテーションからマスタースライドを削除する方法を示します:
```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```


## **FAQ**

**スライドを削除した後、スライドインデックスはどうなりますか？**

削除後、[collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) は再インデックス化され、以降のすべてのスライドが1つ左にシフトします。そのため、以前のインデックス番号は無効になります。安定した参照が必要な場合は、インデックスではなく各スライドの永続的な ID を使用してください。

**スライドの ID はインデックスと異なりますか？また、隣接するスライドが削除されたときに変わりますか？**

はい。インデックスはスライドの位置を表し、スライドの追加や削除に伴って変わります。スライド ID は永続的な識別子であり、他のスライドが削除されても変わりません。

**スライドを削除するとスライド セクションにどのような影響がありますか？**

スライドがセクションに属していた場合、そのセクションのスライド数が1つ減ります。セクションの構造は保たれます。セクションが空になった場合は、必要に応じて[セクションの削除または再編成](/slides/ja/androidjava/slide-section/) が可能です。

**スライドが削除されたとき、ノートやコメントはどうなりますか？**

[Notes](/slides/ja/androidjava/presentation-notes/) と[comments](/slides/ja/androidjava/presentation-comments/) は対象のスライドに紐付いており、スライドとともに削除されます。他のスライドのコンテンツには影響しません。

**スライドの削除と未使用レイアウト/マスターのクリーンアップはどう違いますか？**

削除はデッキから特定の通常スライドを取り除きます。未使用のレイアウト/マスターのクリーンアップは、参照されていないレイアウトスライドやマスタースライドを削除し、残りのスライドの内容を変更せずにファイルサイズを削減します。これらの操作は補完的であり、通常は先にスライドを削除し、次にクリーンアップを実行します。