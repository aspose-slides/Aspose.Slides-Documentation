---
title: Android için Java ile Aspose.Slides
second_title: Android için Aspose.Slides
type: docs
weight: 40
url: /tr/androidjava/
keywords:
- belgeleme
- sunum işleme
- sunum dönüşümü
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Buradan başlayın: Aspose.Slides for Android via Java'yi uygulamanıza ekleyin, ilk sunumu oluşturun ve ortak görevler, API referansı ve destek için kılavuzları bulun."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java, Android uygulamalarında Microsoft PowerPoint olmadan PowerPoint ve OpenDocument sunumları oluşturmak, okumak, düzenlemek ve dönüştürmek için bir sınıf kitaplığıdır.

Makro destekli ve şablon varyantları dahil olmak üzere PPT, PPTX, PPS, POT ve ODP dosyalarını yükler ve kaydeder; ayrıca PDF, XPS, HTML, SVG, TIFF, Markdown ve görüntülere aktarır.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Başlarken</b></p>
<hr>
<p>BAŞLANGIÇ</p>
<ul>
<li><a href="/slides/tr/androidjava/install-aspose-slides-for-android-via-java/">Kurulum</a></li>
<li><a href="/slides/tr/androidjava/create-presentation/">İlk sunumunuzu oluşturun</a></li>
<li><a href="/slides/tr/androidjava/getting-started/">Başlangıç kılavuzu</a></li>
</ul>
<p>DEĞERLENDİR</p>
<ul>
<li><a href="/slides/tr/androidjava/supported-file-formats/">Desteklenen dosya formatları</a></li>
<li><a href="/slides/tr/androidjava/evaluate-aspose-slides/">Deneme sınırlamaları</a></li>
<li><a href="/slides/tr/androidjava/licensing/">Lisanslama</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides ile Oluşturun</b></p>
<hr>
<p>ORTAK GÖREVLER</p>
<ul>
<li><a href="/slides/tr/androidjava/open-presentation/">Bir sunumu aç</a></li>
<li><a href="/slides/tr/androidjava/save-presentation/">Bir sunumu kaydet</a></li>
<li><a href="/slides/tr/androidjava/convert-powerpoint-to-pdf/">PDF'ye dönüştür</a></li>
<li><a href="/slides/tr/androidjava/convert-slide/">Slaytları resim olarak oluştur</a></li>
<li><a href="/slides/tr/androidjava/manage-text/">Metin ve şekilleri düzenle</a></li>
</ul>
<p>SLAYT İŞ AKIŞLARI</p>
<ul>
<li><a href="/slides/tr/androidjava/powerpoint-charts/">Grafikler</a></li>
<li><a href="/slides/tr/androidjava/powerpoint-animation/">Animasyonlar</a></li>
<li><a href="/slides/tr/androidjava/manage-media-files/">Ses ve video</a></li>
<li><a href="/slides/tr/androidjava/presentation-design/">Slayt tasarımı</a></li>
<li><a href="/slides/tr/androidjava/merge-presentation/">Sunumları birleştir</a></li>
</ul>
<p>ÖRNEKLER</p>
<ul>
<li><a href="/slides/tr/androidjava/examples/">Slayt öğesine göre örnekler</a></li>
</ul>
</div>
<div class="col-md-5">
<p><b>Referans &amp; Destek</b></p>
<hr>
<p>REFERANS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">API referansı</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">Sürüm notları</a></li>
<li><a href="/slides/tr/androidjava/known-issues/">Bilinen sorunlar</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">İndir</a></li>
</ul>
<p>DESTEK</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ücretsiz destek forumu</a></li>
<li><a href="https://helpdesk.aspose.com/">Ücretli destek masası</a></li>
</ul>
</div>
</div>

------

## **İlk sunumunuz**

Kütüphane Aspose'un Maven deposundan gelir. Yeni Android Studio projeleri zaten *settings.gradle.kts* içinde bir `dependencyResolutionManagement` bloğuna sahiptir. Aşağıda gösterilen `maven` satırını, ikinci bir blok yapıştırmak yerine, içindeki `repositories` bloğuna ekleyin:

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

Ardından kütüphaneyi *app/build.gradle.kts* dosyasına ekleyin ve projeyi senkronize edin:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Kurulum](/slides/tr/androidjava/install-aspose-slides-for-android-via-java/) Groovy derleme komut dosyalarını, manuel JAR dosyasını ve bir sürüm seçmeyi kapsar. İlk sunumunuz için kod [Sunum Oluşturma](/slides/tr/androidjava/create-presentation/): bir slayta metin kutusu ekler ve sunumu uygulamanızın depolama alanına kaydeder. Bu örnek derlenip bir APK'ye oluşturulmuştur; bir cihazda çalıştırılmamıştır. Lisans olmadan, kaydedilen sunumlar bir değerlendirme filigranı içerir — [Lisanslama](/slides/tr/androidjava/licensing/) sayfasına bakın.