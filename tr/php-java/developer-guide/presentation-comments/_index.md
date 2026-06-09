---
title: PHP'de Sunum Yorumlarını Yönetme
linktitle: Sunum Yorumları
type: docs
weight: 100
url: /tr/php-java/presentation-comments/
keywords:
- yorum
- modern yorum
- PowerPoint yorumları
- sunum yorumları
- slayt yorumları
- yorum ekle
- yoruma eriş
- yorum düzenle
- yorum yanıtla
- yorum kaldır
- yorum sil
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile sunum yorumlarını yönetin: PowerPoint dosyalarında yorumları hızlı ve kolay bir şekilde ekleyin, okuyun, düzenleyin ve silin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum yorumlarını nasıl yöneteceğinizi açıklar. Ana yorumla ilgili türleri gösterir ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlarla çalışma, modern yorumları kullanma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint’te yaygın inceleme ve işbirliği senaryolarına odaklanır; örneğin yorumları yazarlarla ilişkilendirme, yorum içeriğini ve meta verilerini okuma, yanıt zincirleri oluşturma ve tüm yorumları temizleme veya seçilenleri silme.

PowerPoint’te bir yorum, bir slayt üzerindeki not veya açıklama olarak görünür. Bir yorum tıklandığında, içeriği veya mesajları gösterilir. 

## **Sunumlara Neden Yorum Eklemeliyiz?**

Sunumları incelerken geri bildirim sağlamak veya meslektaşlarınızla iletişim kurmak için yorumları kullanmak isteyebilirsiniz.

PowerPoint sunumlarında yorumları kullanabilmeniz için Aspose.Slides for PHP via Java aşağıdakileri sağlar:

* The [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı, yazar koleksiyonlarını ([CommentAuthorCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/commentauthorcollection/) sınıfından) içerir. Yazarlar slaytlara yorum ekler.
* The [CommentCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/commentcollection/) sınıfı, bireysel yazarlar için yorum koleksiyonunu içerir.
* The [Comment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/) sınıfı, yazarlar ve yorumları hakkında bilgi içerir: yorumu kimin eklediği, eklenme zamanı, yorumun konumu vb.
* The [CommentAuthor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/commentauthor/) sınıfı, bireysel yazarlar hakkında bilgi içerir: yazarın adı, baş harfleri, yazar adının ilişkili olduğu yorumlar vb.

## **Slayt Yorumları Ekleme**
Bu PHP kodu, PowerPoint sunumundaki bir slayta nasıl yorum ekleneceğini gösterir:

```php
  # Presentation sınıfını örnekler
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Boş bir slayt ekler
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Bir yazar ekler
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Yorumların konumunu ayarlar
    $point = new Point2DFloat(0.2, 0.2);
    # Yazar için slayt 1'de slayt yorumu ekler
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Yazar için slayt 2'de slayt yorumu ekler
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # ISlide 1'e erişir
    $slide = $pres->getSlides()->get_Item(0);
    # Argüman olarak null gönderildiğinde, tüm yazarların yorumları seçilen slayta getirilir
    $Comments = $slide->getSlideComments($author);
    # Slayt 1 için 0. indeksteki yoruma erişir
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Yazarın yorum koleksiyonunu 0. indekste seçer
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Slayt Yorumlarına Erişme**
Bu PHP kodu, PowerPoint sunumundaki bir slaytta mevcut bir yoruma nasıl erişileceğini gösterir:

```php
  # Presentation sınıfının bir örneğini oluşturur
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " has comment: " . $comment->getText() . " with Author: " . $comment->getAuthor()->getName() . " posted on time :" . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Yorumlara Yanıt Verme**
Üst yorum, bir yorum hiyerarşisindeki en üst veya orijinal yorumdur. [Comment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/) sınıfındaki [getParentComment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/getparentcomment/) veya [setParentComment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/setparentcomment/) yöntemlerini kullanarak bir üst yorum ayarlayabilir veya alabilirsiniz.

Bu PHP kodu, yorum eklemeyi ve onlara yanıt almayı gösterir:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Yorumu ekler
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # comment1'e yanıt ekler
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # comment1'e başka bir yanıt ekler
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Mevcut bir yanıta yanıt ekler
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Yorum hiyerarşisini konsola gösterir
    $slide = $pres->getSlides()->get_Item(0);
    $comments = $slide->getSlideComments(null);
    for($i = 0; $i < java_values($Array->getLength($comments)) ; $i++) {
      $comment = $comments[$i];
      while (!java_is_null($comment->getParentComment())) {
        System->out->print("\t");
        $comment = $comment->getParentComment();
      } 
      echo($comments[$i]->getAuthor()->getName() . " : " . $comments[$i]->getText());
      echo();
    }
    $pres->save("parent_comment.pptx", SaveFormat::Pptx);
    # comment1'i ve ona ait tüm yanıtları kaldırır
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Attention" %}} 

* [remove](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/remove/) yöntemi ([Comment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/) sınıfından) bir yorumu silmek için kullanıldığında, yorumun yanıtları da silinir.
* [setParentComment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/setparentcomment/) ayarı dairesel bir başvuru oluşturursa, [PptxEditException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxeditexception/) istisnası fırlatılır.

{{% /alert %}}

## **Modern Yorumlar Ekleme**

2021 yılında Microsoft, PowerPoint’te *modern yorumlar* özelliğini tanıttı. Modern yorumlar özelliği, PowerPoint’te iş birliğini önemli ölçüde iyileştirir. Modern yorumlar sayesinde PowerPoint kullanıcıları yorumları çözümleyebilir, yorumları nesnelere ve metinlere bağlayabilir ve etkileşimleri çok daha kolay bir şekilde gerçekleştirebilir.

Aspose Slides, [ModernComment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/) sınıfı ile modern yorumları destekler. [CommentCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/commentcollection/) sınıfına [addModernComment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/commentcollection/addmoderncomment/) ve [insertModernComment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/commentcollection/insertmoderncomment/) yöntemleri eklenmiştir.

Bu PHP kodu, PowerPoint sunumundaki bir slayta modern yorum nasıl eklenir gösterir:

```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Some Author", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("This is a modern comment", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Yorumları Kaldırma**

### **Tüm Yorumları ve Yazarları Sil**

Bu PHP kodu, bir sunumdaki tüm yorumları ve yazarları nasıl kaldıracağınızı gösterir:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Sunumdaki tüm yorumları siler
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # Tüm yazarları siler
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Belirli Yorumları Sil**

Bu PHP kodu, bir slayttaki belirli yorumların nasıl silineceğini gösterir:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # yorumları ekle...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # \"comment 1\" metnini içeren tüm yorumları kaldır
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("comment 1")) {
          $toRemove->add($comment);
        }
      }
      foreach($toRemove as $comment) {
        $commentAuthor->getComments()->remove($comment);
      }
    }
    $presentation->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **SSS**

**Aspose.Slides, modern yorumlar için 'çözülmüş' gibi bir durumu destekliyor mu?**

Evet. [Modern comments](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/) sınıfı bir [setStatus](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncomment/setstatus/) yöntemi sunar; bir [yorumun durumunu](https://reference.aspose.com/slides/tr/php-java/aspose.slides/moderncommentstatus/) (örneğin çözülmüş olarak işaretlemek) yazabilir ve bu durum dosyada kaydedilir, PowerPoint tarafından tanınır.

**İşlemeli tartışmalar (yanıt zincirleri) destekleniyor mu ve bir iç içe limit var mı?**

Evet. Her yorum, kendi [parent comment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/comment/getparentcomment/) referansını tutabilir, bu da isteğe bağlı yanıt zincirleri oluşturur. API belirli bir derinlik sınırı belirtmez.

**Bir slayttaki yorum işaretinin konumu hangi koordinat sisteminde tanımlanır?**

Konum, slaydın koordinat sisteminde kayan noktalı bir nokta olarak saklanır. Bu, yorum işaretini tam olarak istediğiniz yere yerleştirmenizi sağlar.