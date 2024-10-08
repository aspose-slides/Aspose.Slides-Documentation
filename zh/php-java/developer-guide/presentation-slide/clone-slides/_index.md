---
title: 克隆幻灯片
type: docs
weight: 35
url: /php-java/clone-slides/
---


## **在演示文稿中克隆幻灯片**
克隆是制作某物的精确副本或复制品的过程。Aspose.Slides for PHP via Java 使得可以复制或克隆任何幻灯片，然后将克隆的幻灯片插入到当前或任何其他打开的演示文稿中。幻灯片克隆的过程生成一个新的幻灯片，开发人员可以对其进行修改，而不更改原始幻灯片。克隆幻灯片有几种可能的方法：

- 在演示文稿末尾克隆。
- 在演示文稿的另一个位置克隆。
- 在另一演示文稿的末尾克隆。
- 在另一演示文稿的另一个位置克隆。
- 在另一演示文稿的特定位置克隆。

在 Aspose.Slides for PHP via Java 中，所暴露的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 对象提供的 (一组 [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) 对象) 提供 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 和 [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，以执行上述类型的幻灯片克隆。

## **在演示文稿末尾克隆**
如果您想克隆一个幻灯片，然后在现有幻灯片的末尾在同一演示文稿文件中使用它，请根据以下步骤使用 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过引用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 对象所暴露的幻灯片集合实例化 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 类。
3. 调用 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 对象所暴露的 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将要克隆的幻灯片作为参数传递给 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。
4. 写入修改后的演示文稿文件。

在下面给出的示例中，我们已经将一个幻灯片（位于演示文稿的第一个位置 - 零索引）克隆到演示文稿的末尾。

```php
  # 实例化表示演示文稿文件的 Presentation 类
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # 将所需幻灯片克隆到同一演示文稿的幻灯片集合的末尾
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # 将修改后的演示文稿写入磁盘
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **在演示文稿的另一个位置克隆**
如果您想克隆一个幻灯片，然后在同一演示文稿文件中使用它但在不同的位置，请使用 [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过引用 [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 集合实例化该类，该集合由 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 对象所暴露。
3. 调用 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 对象所暴露的 [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，并将要克隆的幻灯片及新位置的索引作为参数传递给 [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法。
4. 将修改后的演示文稿写入为 PPTX 文件。

在下面给出的示例中，我们已经将一个幻灯片（位于零索引 - 位置 1 – 的演示文稿）克隆到演示文稿的索引 1 – 位置 2。

```php
  # 实例化表示演示文稿文件的 Presentation 类
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # 将所需幻灯片克隆到同一演示文稿的幻灯片集合的末尾
    $slds = $pres->getSlides();
    # 将所需幻灯片克隆到同一演示文稿的指定索引
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # 将修改后的演示文稿写入磁盘
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **在另一演示文稿的末尾克隆**
如果您需要从一个演示文稿克隆幻灯片并在另一个演示文稿文件中使用它，位于现有幻灯片的末尾：

1. 创建包含要克隆的幻灯片的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 创建包含要将幻灯片添加到的目标演示文稿的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
3. 通过引用目标演示文稿的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 对象所暴露的 [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 集合实例化 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) 类。
4. 调用 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法所暴露的 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 对象，并将源演示文稿中的幻灯片作为参数传递给 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。
5. 写入修改后的目标演示文稿文件。

在下面的示例中，我们已经将一个幻灯片（来自源演示文稿的第一个索引）克隆到目标演示文稿的末尾。

```php
  # 实例化 Presentation 类以加载源演示文稿文件
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # 实例化目标 PPTX 的 Presentation 类（将克隆幻灯片的地方）
    $destPres = new Presentation();
    try {
      # 从源演示文稿的幻灯片集合克隆所需幻灯片到目标演示文稿的幻灯片集合的末尾
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # 将目标演示文稿写入磁盘
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **在另一演示文稿的另一个位置克隆**
如果您需要从一个演示文稿中克隆幻灯片并在另一个演示文稿文件中使用它，位于特定位置：

1. 创建包含要克隆的幻灯片的源演示文稿的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 创建包含要将幻灯片添加到的目标演示文稿的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
3. 通过引用目标演示文稿的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 对象所暴露的幻灯片集合实例化 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 类。
4. 调用 [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法所暴露的 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 对象，并将源演示文稿中的幻灯片与所需位置一起作为参数传递给 [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法。
5. 写入修改后的目标演示文稿文件。

在下面的示例中，我们已经将一个幻灯片（来自源演示文稿的零索引）克隆到目标演示文稿的索引 1（位置 2）。

```php
  # 实例化 Presentation 类以加载源演示文稿文件
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # 实例化目标 PPTX 的 Presentation 类（将克隆幻灯片的地方）
    $destPres = new Presentation();
    try {
      # 从源演示文稿的幻灯片集合克隆所需幻灯片到目标演示文稿的幻灯片集合的末尾
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # 将目标演示文稿写入磁盘
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **在另一演示文稿的特定位置克隆**
如果您需要克隆具有母版幻灯片的幻灯片，从一个演示文稿中并在另一个演示文稿中使用它，您需要首先将所需的母版幻灯片从源演示文稿克隆到目标演示文稿。然后，您需要使用该母版幻灯片来克隆具有母版幻灯片的幻灯片。 [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 期望接收来自目标演示文稿的母版幻灯片，而不是来自源演示文稿的母版幻灯片。为了使用母版克隆幻灯片，请遵循以下步骤：

1. 创建包含要克隆的幻灯片的源演示文稿的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 创建包含要克隆到的目标演示文稿的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
3. 访问要克隆的幻灯片及其母版幻灯片。
4. 通过引用目标演示文稿的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 对象所暴露的母版集合实例化 [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) 类。
5. 调用 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法所暴露的 [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) 对象，并将要克隆的源 PPTX 中的母版作为参数传递给 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。
6. 通过设置对目标演示文稿的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 对象所暴露的幻灯片集合的引用实例化 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 类。
7. 调用 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法所暴露的 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 对象，并将要克隆的源演示文稿中的幻灯片和母版作为参数传递给 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。
8. 写入修改后的目标演示文稿文件。

在下面给出的示例中，我们已经将一个具有母版的幻灯片（位于源演示文稿的零索引）克隆到了目标演示文稿的末尾，使用的母版来自源幻灯片。

```php
  # 实例化 Presentation 类以加载源演示文稿文件
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # 实例化目标演示文稿的 Presentation 类（将克隆幻灯片的地方）
    $destPres = new Presentation();
    try {
      # 从源演示文稿的幻灯片集合实例化 ISlide，同时获取母版幻灯片
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # 将所需母版幻灯片从源演示文稿克隆到目标演示文稿中的母版集合
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # 将所需母版幻灯片从源演示文稿克隆到目标演示文稿中的母版集合
      $iSlide = $masters->addClone($SourceMaster);
      # 从源演示文稿中克隆所需幻灯片，并将其与目标演示文稿中的母版结合，放到幻灯片集合的末尾
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # 保存目标演示文稿到磁盘
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **在指定部分的末尾克隆**
如果您想克隆一个幻灯片，然后在同一演示文稿文件中使用它，但在不同的部分中，则使用 [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 方法，该方法由 [**ISlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) 接口所暴露。Aspose.Slides for PHP via Java 可以从第一部分克隆幻灯片，然后将克隆的幻灯片插入到同一演示文稿的第二部分。

以下代码片段向您展示如何克隆一个幻灯片并将其插入到指定部分中。

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("第 1 部分", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("第 2 部分");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # 将目标演示文稿保存到磁盘
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```