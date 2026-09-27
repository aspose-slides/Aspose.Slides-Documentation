---
title: Lisanslama
type: docs
weight: 90
url: /tr/androidjava/licensing/
keywords:
- lisans
- geçici lisans
- lisans ayarla
- lisans kullan
- lisans doğrula
- lisans dosyası
- değerlendirme sürümü
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'da lisansları uygulayın, yönetin ve sorunları giderin. Lisanslama kılavuzumuzla tam özelliklere kesintisiz erişimi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, değerlendirme modunda veya geçerli bir lisansla kullanılabilir. Değerlendirme sürümü, lisanslı sürümle aynı işlevselliği sağlar, ancak kaydettiği her sunumun her slaytına bir değerlendirme filigranı ekler ve kodunuzun sunumlardan okuduğu metni kısaltır.

Bu makale, Aspose.Slides’da lisanslamanın nasıl çalıştığını ve kütüphaneyi kullanmadan önce nasıl bir lisans uygulayacağınızı açıklar. Bir lisans, [License](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/license/) sınıfı kullanılarak bir dosyadan, akıştan veya gömülü kaynaktan yüklenebilir. Makale ayrıca bir lisansın doğru şekilde uygulanıp uygulanmadığını nasıl doğrulayacağınızı da gösterir.

## **Aspose.Slides Değerlendirme**

{{% alert color="info" title="Not" %}}
Aspose.Slides for Android via Java’nın **değerlendirme sürümünü**, [indirme sayfası](https://releases.aspose.com/slides/tr/androidjava/) üzerinden indirebilirsiniz. Değerlendirme sürümü, ürünün lisanslı sürümüyle aynı işlevleri sağlar. Değerlendirme paketi, satın alınan paketle aynıdır. Değerlendirme sürümü, yalnızca birkaç satır kod ekleyerek (lisansı uygulamak için) lisanslı hâle gelir.

**Aspose.Slides** değerlendirme sürecinizden memnun kaldıktan sonra, [bir lisans satın alabilirsiniz](https://purchase.aspose.com/pricing/slides/tr/android-java/). Farklı abonelik türlerini incelemenizi öneririz. Sorularınız varsa, Aspose satış ekibiyle iletişime geçin.

Her Aspose lisansı, abonelik süresi içinde yayınlanan yeni sürümlere veya düzeltmelere ücretsiz yükseltmeler sağlayan bir yıllık ücretsiz abonelikle birlikte gelir. Lisanslı ürünleri (ve hatta değerlendirme sürümleri) kullanan kullanıcılar, sınırsız ve ücretsiz teknik destek alırlar.
{{% /alert %}} 

**Değerlendirme sürümü sınırlamaları**

* Lisans belirtilmemiş değerlendirme sürümü, tam ürün işlevselliği sağlar, ancak kaydettiği her sunumun her slaytına bir değerlendirme filigranı metin kutusu ekler.
* Kodunuzun bir sunumdan okuduğu metin, ilk birkaç karakterine kısaltılır ve değerlendirme sınırlamasına dair bir uyarı eklenir. Kodunuzun yazdığı metin tam olarak kaydedilir.

{{% alert color="info" title="Not" %}}
Aspose.Slides’ı sınırlama olmadan test etmek için **30 Günlük Geçici Lisans** isteyebilirsiniz. Daha fazla bilgi için [Geçici Lisans Nasıl Alınır](https://purchase.aspose.com/temporary-license) sayfasına bakın.
{{% /alert %}}

## **Aspose.Slides’da Lisanslama**

* Değerlendirme sürümü, bir lisans satın alıp birkaç satır kod ekleyerek (lisansı uygulamak için) lisanslı hâle gelir.
* Lisans, ürün adı, lisanslı geliştirici sayısı, abonelik bitiş tarihi gibi bilgileri içeren düz metin XML dosyasıdır. 
* Lisans dosyası dijital olarak imzalanmıştır; dosyayı değiştirmemelisiniz. Dosyanın içeriğine istemeden ekstra bir satır sonu eklemek dahi lisansı geçersiz kılar.
* Aspose.Slides for Android via Java, lisansı aşağıdaki konumlardan bulmaya çalışır:
  * Açık bir yol
  * Aspose.Slides.jar dosyasını içeren klasör
* Değerlendirme sürümüyle ilişkili sınırlamaları önlemek için **Aspose.Slides** kullanmadan önce bir lisans ayarlamanız gerekir. Bir uygulama veya süreç için sadece bir kez lisans ayarlamanız yeterlidir.

## **Lisans Uygulama**

Lisans bir **dosyadan** veya **akıştan** yüklenebilir.

{{% alert color="info" title="Not" %}}
Aspose.Slides, lisans işlemleri için [License](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/license/) sınıfını sağlar.
{{% /alert %}} 

{{% alert color="warning" title="Uyarı" %}}
Yeni lisanslar, yalnızca 21.4 ve sonrası sürümlerle Aspose.Slides’ı etkinleştirebilir. Daha eski sürümler farklı bir lisans sistemini kullanır ve bu lisansları tanımaz.
{{% /alert %}}

### **Dosya**

Lisans ayarlamanın en kolay yöntemi, lisans dosyasını Aspose.Slides.jar dosyasını veya uygulamanızın jar dosyasını içeren klasöre yerleştirmektir.

{{% alert color="info" title="Not" %}}
Android’de kütüphane ve uygulamanız APK içinde paketlendiği için, kütüphanenin JAR dosyasını içeren bir klasör yoktur ve *Aspose.Slides.Android.via.Java.lic* gibi bir göreli yol uygulamanızda bir dosyaya işaret etmez. Lisans dosyasını uygulamanızın *assets* klasörüne ekleyin ve [Uygulama Varlıklarından Akış](#stream-from-app-assets) bölümünde gösterildiği gibi bir akıştan yükleyin.
{{% /alert %}}

Bu Java kodu, bir lisans dosyasının nasıl ayarlanacağını gösterir:

``` java
// License sınıfını örnekler
com.aspose.slides.License license = new com.aspose.slides.License();

// Lisans dosyası yolunu ayarlar
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Uyarı" %}}
Lisans dosyasını farklı bir dizine koyarsanız, [setLicense](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) metodunu çağırdığınızda belirtilen yolun sonunda yer alan dosya adı lisans dosyanızın adıyla aynı olmalıdır.

Örneğin, lisans dosyasının adını *Aspose.Slides.Android.via.Java.lic.xml* olarak değiştirebilirsiniz. Ardından kodunuzda, yolu ( *Aspose.Slides.Android.via.Java.lic.xml* ile biten) [setLicense](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) metoduna geçirmeniz gerekir.
{{% /alert %}}

### **Akış**

Bir lisansı akıştan yükleyebilirsiniz. Bu Java kodu, bir akıştan lisans uygulamanın nasıl yapılacağını gösterir:

``` java
// License sınıfını örnekler
com.aspose.slides.License license = new com.aspose.slides.License();

// Lisansı bir akış üzerinden ayarlar
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **Uygulama Varlıklarından Akış**

Android uygulamasında, lisans dosyasını uygulama modülünün *assets* klasörüne, *app/src/main/assets* içine koyun; böylece APK’ye paketlenir. Dosyayı [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) metodu ile açın ve akışı [setLicense](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) metoduna geçirin. Kod, bir `Activity` içinde, örneğin `onCreate` metodunda, Aspose.Slides kullanılmadan önce çalıştırılır:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

[open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) metoduna geçirilen dosya adı, *assets* klasörüne görecelidir. Dosya orada yoksa kod hatayı kaydeder ve Aspose.Slides değerlendirme modunda kalır. Lisansın uygulanıp uygulanmadığını kontrol etmek için [Lisans Doğrulama](#validating-a-license) bölümüne bakın.

## **Lisans Doğrulama**

Bir lisansın düzgün şekilde ayarlanıp ayarlanmadığını doğrulamak için lisansı doğrulayabilirsiniz. Bu Java kodu, bir lisansı nasıl doğrulayacağınızı gösterir:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **İş Parçacığı Güvenliği**

{{% alert color="warning" title="Uyarı" %}}
[setLicense](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) metodu iş parçacığı güvenli değildir. Bu metodun birçok iş parçacığından aynı anda çağrılması gerekiyorsa, sorunları önlemek için bir kilit gibi eşzamanlama primitifleri kullanmanız önerilir.
{{% /alert %}}

## **SSS**

### Lisansı tamamen çevrim dışı bir ortamda (internet erişimi olmadan) uygulayabilir miyim?

Evet. Lisans doğrulaması, lisans dosyası kullanılarak yerel olarak yapılır; internet bağlantısı gerektirmez.

### Bir yıllık abonelik süresi dolduktan sonra ne olur? Kütüphane çalışmayı durdurur mu?

Hayır. Lisans süresizdir: Abonelik bitiş tarihinizden önce yayınlanan sürümleri kullanmaya devam edebilirsiniz; ancak yenileme yapmazsanız daha yeni sürümleri kullanamazsınız.