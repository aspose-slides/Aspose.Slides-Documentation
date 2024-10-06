---
title: プレゼンテーションにスライドを追加
type: docs
weight: 10
url: /ja/php-java/add-slide-to-presentation/
---

## **プレゼンテーションにスライドを追加**
{{% alert color="primary" %}} 

プレゼンテーションファイルにスライドを追加することについて話す前に、スライドに関するいくつかの事実を議論しましょう。各PowerPointプレゼンテーションファイルには**マスター/レイアウト**スライドと他の**通常**スライドが含まれています。つまり、プレゼンテーションファイルには1つ以上のスライドが含まれている必要があります。スライドのないプレゼンテーションファイルは、Aspose.Slides for PHP via Javaではサポートされていないことを知っておくことが重要です。各スライドには一意のIdがあり、すべての通常スライドはゼロベースのインデックスによって指定された順序に配置されています。

{{% /alert %}} 

Aspose.Slides for PHP via Javaは、開発者がプレゼンテーションに空のスライドを追加することを可能にします。プレゼンテーションに空のスライドを追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)オブジェクトによって公開された[Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)（コンテンツスライドオブジェクトのコレクション）プロパティに参照を設定することで、[ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection)クラスをインスタンス化します。
- [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection)オブジェクトによって公開された[**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-)メソッドを呼び出すことで、コンテンツスライドコレクションの最後に空のスライドを追加します。
- 新しく追加した空のスライドで何か作業をします。
- 最後に、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)オブジェクトを使用してプレゼンテーションファイルを書き込みます。

```php
  # プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # SlideCollectionクラスをインスタンス化
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Slidesコレクションに空のスライドを追加
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # 新しく追加したスライドで作業
    # PPTXファイルをディスクに保存
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```