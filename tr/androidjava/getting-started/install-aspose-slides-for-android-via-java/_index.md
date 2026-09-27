---
title: Aspose.Slides for Android via Java'ı Yükleyin
type: docs
weight: 90
url: /tr/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- Aspose.Slides kurulum
- Aspose.Slides indirme
- Aspose.Slides kullanma
- Aspose.Slides kurulumu
- Gradle
- Maven deposu
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'ı, Aspose'un Maven deposundan Gradle ile bir Android Studio projesine ekleyin ya da JAR dosyasını manuel olarak ekleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Android via Java'ı bir Android projesine nasıl ekleyeceğinizi açıklar. Önerilen yöntem, Gradle'ın kütüphaneyi Aspose'un Maven deposundan indirmesini sağlamaktır. Ayrıca JAR dosyasını indirip projenize manuel olarak ekleyebilirsiniz.

Kütüphane Maven Central veya Google'ın Maven deposunda yayımlanmamaktadır. Aspose'un kendi deposundan, `aspose-slides` artefaktı ve `android.via.java` sınıflandırıcısı olarak temin edilebilir.

## **Aspose'un Maven Deposundan Kurulum**

### **Adım 1: Depoyu Ekle**

Yeni Android Studio projeleri, depolarını *settings.gradle.kts* dosyasındaki `dependencyResolutionManagement` bloğunda bildirir ve Gradle, bir modülün build dosyasının eklediği depoları reddeder. Aşağıda gösterilen `maven` satırını mevcut bloğun içindeki `repositories` bloğuna ekleyin; ikinci bir `dependencyResolutionManagement` bloğu yapıştırmayın:

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

### **Adım 2: Bağımlılığı Ekle**

Kütüphaneyi app modülünün build dosyası *app/build.gradle.kts* içindeki `dependencies` bloğuna ekleyin:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

Koordinatların son kısmı olan `android.via.java`, kütüphanenin Android derlemesini seçen sınıflandırıcıdır. Bu olmadan Gradle artefaktı bulamaz.

Ardından projeyi Gradle dosyalarıyla senkronize edin, böylece Gradle kütüphaneyi indirir.

### **Bir Sürüm Seçin**

Aspose.Slides for Android via Java, depodaki her sürüm için oluşturulmamıştır. Derlemeleri yalnızca bazı Aspose.Slides for Java sürümleri için yayımlanır ve Android derlemesi olmayan bir sürüm çözülemez. [Aspose.Slides for Android via Java indirme sayfasında](https://releases.aspose.com/slides/tr/androidjava/) listelenen bir sürümü seçin.

### **Groovy Yapı Betikleri**

Projeniz Groovy yapı betikleri kullanıyorsa, mevcut `dependencyResolutionManagement` bloğunun içindeki `repositories` bloğuna `maven` satırını ekleyin *settings.gradle* dosyasında:

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

Ve bağımlılığı *app/build.gradle* dosyasına ekleyin:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **JAR Dosyasını Manuel Olarak Ekleyin**

Bir Maven deposu kullanamıyorsanız, JAR dosyasını projenize ekleyin:

1. JAR dosyasını, [Aspose'un Maven deposundaki](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) sürüm klasöründen indirin. 26.9 sürümü için dosya, *26.9* klasöründe *aspose-slides-26.9-android.via.java.jar* olarak bulunmaktadır.
2. Dosyayı projenizin *app/libs* klasörüne kopyalayın. Klasör yoksa oluşturun.
3. Dosyayı *app/build.gradle.kts* dosyasındaki `dependencies` bloğuna ekleyin, ardından projeyi senkronize edin:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **İlk Sunumunuzu Oluşturun**

Proje senkronize edildikten sonra, [Sunum Oluşturma](/slides/tr/androidjava/create-presentation/) bölümüne devam edin. İlk örnek, bir slayta metin kutusu ekler ve sunumu uygulamanızın özel depolamasına kaydeder; bu işlem için depolama izni gerekmez. Lisans olmadan, Aspose.Slides kaydettiği her slayta değerlendirme filigranı ekler; [Lisanslandırma](/slides/tr/androidjava/licensing/) bölümüne bakın.

## **Sürümleme**

2018'den beri, Aspose.Slides for Android via Java'ın sürümlemesi Aspose.Slides for Java ile uyumludur. Android derlemeleri her Java sürümü için yayımlanmaz; [Bir Sürüm Seçin](#choose-a-version) bölümüne bakın.

## **SSS**

### Aspose.Slides'ın doğru şekilde entegre edildiğini nasıl doğrulayabilirim?

Projenizi derleyin, boş bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) nesnesi oluşturun ve yeni bir adla kaydedin. Dosya istisna fırlatmadan oluşturulursa, kütüphane başarılı bir şekilde entegre edilmiştir.

### Büyük sunumları işlerken bellek tüketimini nasıl sınırlayabilirim?

Her bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneğinin `finally` bloğunda [dispose](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#dispose--) metodunu çağırarak kaynaklarını hemen serbest bırakın ve aynı anda yalnızca bir büyük sunumu işleyin. Bu, bellek taşması hatalarını önlemeye yardımcı olur ve toplu işlemler sırasında genel bellek kullanımının öngörülebilir kalmasını sağlar.

### İstenmeyen dışa aktarma formatlarını hariç tutarak JAR boyutunu küçültebilir miyim?

Mevcut Aspose.Slides sürümleri tek bir bütünsel kütüphane olarak dağıtıldığından, PDF veya SVG gibi belirli dışa aktarıcıları derleme zamanında devre dışı bırakamazsınız.