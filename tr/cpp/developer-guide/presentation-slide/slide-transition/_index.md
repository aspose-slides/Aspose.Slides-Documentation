---
title: C++ Kullanarak Sunumlarda Slayt Geçişlerini Yönetme
linktitle: Slayt Geçişi
type: docs
weight: 80
url: /tr/cpp/slide-transition/
keywords:
- slayt geçişi
- slayt geçişi ekle
- slayt geçişi uygula
- gelişmiş slayt geçişi
- Morph geçişi
- geçiş türü
- geçiş efekti
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde slayt geçişlerini nasıl özelleştireceğinizi keşfedin; PowerPoint ve OpenDocument sunumları için adım adım rehberlik sağlar."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunularda slayt geçişlerini nasıl yöneteceğinizi açıklar. Geçiş türlerini slaytlara nasıl uygulayacağınızı, tıklama ile ilerleme veya belirtilen bir süreden sonra ilerleme gibi geçiş davranışını nasıl yapılandıracağınızı, otomatik ilerlemeyi nasıl kontrol edip devre dışı bırakacağınızı, Morph geçişini ve türlerini nasıl kullanacağınızı ve geçiş efekti seçeneklerini nasıl ayarlayacağınızı gösterir. Örnekler, bir sunumu nasıl yükleyeceğinizi veya oluşturacağınızı, seçili slaytlar için geçiş ayarlarını nasıl değiştireceğinizi ve sonucu PPTX dosyası olarak nasıl kaydedeceğinizi gösterir. Makale ayrıca geçiş hızı, geçiş sesleri, aynı geçişin birden fazla slayta uygulanması ve bir slaytta şu anda ayarlanmış olan geçişin kontrol edilmesi gibi yaygın soruları yanıtlar.

## **Slayt Geçişi Ekle**

Anlamayı kolaylaştırmak için, Aspose.Slides for C++'ın basit slayt geçişlerini yönetmek için kullanımını gösterdik. Geliştiriciler yalnızca slaytlara farklı slayt geçiş efektleri uygulamakla kalmaz, aynı zamanda bu geçiş efektlerinin davranışını da özelleştirebilirler. Basit bir slayt geçiş efekti oluşturmak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.
2. Aspose.Slides for C++ tarafından sunulan geçiş efektlerinden birini TransitionType enum'ı aracılığıyla slayta bir Slayt Geçişi Türü olarak uygulayın.
3. Değiştirilmiş sunum dosyasını yazın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Gelişmiş Slayt Geçişi Ekle**

Yukarıdaki bölümde yalnızca slayta basit bir geçiş efekti uyguladık. Şimdi, bu basit geçiş efektini daha iyi ve kontrol edilebilir hale getirmek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.
2. Aspose.Slides for C++ tarafından sunulan geçiş efektlerinden birini slayta bir Slayt Geçişi Türü olarak uygulayın.
3. Geçişi Tıklamayla İlerleme, belirli bir zaman diliminden sonra veya ikisi birden olacak şekilde ayarlayabilirsiniz.
4. Slayt geçişi Tıklamayla İlerleme olarak etkinleştirilmişse, geçiş yalnızca birisi fareyi tıkladığında ilerleyecektir. Ayrıca, Advance After Time özelliği ayarlanmışsa, geçiş belirtilen süre geçtikten sonra otomatik olarak ilerleyecektir.
5. Değiştirilmiş sunumu bir sunum dosyası olarak yazın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Morph Geçişi**

Aspose.Slides for C++ artık Morph Geçişini destekliyor. Bu geçişler, PowerPoint 2019’da tanıtılan yeni morph geçişini temsil eder. Morph geçişi, bir slayttan diğerine sorunsuz bir hareketi canlandırmanıza olanak tanır. Bu makale konsepti ve Morph geçişinin nasıl kullanılacağını açıklar. Morph geçişini etkili bir şekilde kullanmak için ortak en az bir nesneye sahip iki slaytınızın olması gerekir. En kolay yol, slaytı çoğaltmak ve ikinci slayttaki nesneyi başka bir konuma taşımaktır.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Morph Geçişi Türleri**

Yeni Aspose.Slides.SlideShow.TransitionMorphType enum'u eklendi. Bu, farklı Morph slayt geçişi türlerini temsil eder.

TransitionMorphType enum'unun üç üyesi vardır:

- ByObject: Morph geçişi, şekilleri bölünemez nesneler olarak ele alarak gerçekleştirilir.
- ByWord: Morph geçişi, mümkün olduğunda metni kelimeler halinde aktararak gerçekleştirilir.
- ByChar: Morph geçişi, mümkün olduğunda metni karakterler halinde aktararak gerçekleştirilir.

İşte aşağıdaki kod parçacığı, slayta morph geçişi nasıl ayarlanır ve morph türü nasıl değiştirilir göstermektedir:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **Geçiş Efektlerini Ayarlama**

Aspose.Slides for C++ siyah'tan, soldan, sağdan vb. gibi geçiş efektlerini ayarlamayı destekler. Geçiş Efektini ayarlamak için aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun.
- Slaytın referansını alın.
- Geçiş efektini ayarlayın.
- Sunumu bir PPTX dosyası olarak yazın.

Aşağıda verilen örnekte geçiş efektlerini ayarladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **FAQ**

**Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Geçişin [speed](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) özelliğini [TransitionSpeed](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/transitionspeed/) ayarını (ör. yavaş/orta/hızlı) kullanarak ayarlayabilirsiniz.

**Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. Geçiş için bir ses gömebilir ve ses modu ve döngü gibi ayarlarla davranışı kontrol edebilirsiniz (ör. [set_Sound](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/), ayrıca [set_SoundIsBuiltIn](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) ve [set_SoundName](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/) gibi meta veriler).

**Aynı geçişi her slayta uygulamanın en hızlı yolu nedir?**

İstenen geçiş türünü her slaydın geçiş ayarlarında yapılandırın; geçişler slayt başına depolanır, bu nedenle aynı türü tüm slaytlara uygulamak tutarlı bir sonuç verir.

**Bir slaytta şu anda ayarlanmış olan geçişi nasıl kontrol edebilirim?**

Slaydın [transition settings](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseslide/get_slideshowtransition/) özelliğini inceleyin ve [transition type](https://reference.aspose.com/slides/tr/cpp/aspose.slides.slideshow/slideshowtransition/get_type/) değerini okuyun; bu değer hangi etkinin uygulandığını kesin olarak gösterir.