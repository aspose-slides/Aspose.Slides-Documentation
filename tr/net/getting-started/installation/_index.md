---
title: Kurulum
type: docs
weight: 70
url: /tr/net/installation/
keywords:
- Aspose.Slides'i kur
- Aspose.Slides'i indir
- Aspose.Slides'i kullan
- Aspose.Slides kurulumu
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "NuGet üzerinden Windows, Linux ve macOS'ta .NET için Aspose.Slides'i kurun: iki paket arasından seçim yapın, .NET CLI veya Visual Studio ile birini ekleyin ve Linux önkoşullarını kurun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET'i Windows, Linux ve macOS üzerindeki bir projeye nasıl ekleyeceğinizi açıklar. Aspose.Slides NuGet aracılığıyla dağıtılır. Herhangi bir işletim sisteminde .NET CLI ile ekleyebilir, Windows'ta Visual Studio'da NuGet Paketi Yöneticisi veya Paket Yöneticisi Konsolu ile ekleyebilirsiniz. Makale ayrıca iki NuGet paketinden hangisinin seçileceği ve Linux için ek olarak nelerin gerektiğini açıklar.

Kurulumdan önce, desteklenen işletim sistemlerini, .NET uygulamalarını ve ek bağımlılıkları [System Requirements](/slides/tr/net/system-requirements/) içinde inceleyin.

## **Paket Seçimi**

Aspose.Slides for .NET iki NuGet paketi olarak yayımlanır. Her ikisi de aynı Aspose.Slides ad alanlarını ve sınıflarını sağlar, bu nedenle paketler arasında geçiş yaptığınızda kodunuz değişmez; yalnızca paket referansı ve platform gereksinimleri farklıdır.

| Paket | Kullanım Alanı | Ek gereksinimler |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Windows ve .NET Framework uygulamaları | Linux ve macOS'ta: `libgdiplus` kitaplığı ve uygulama başlangıcında etkinleştirilen `System.Drawing.EnableUnixSupport` anahtarı |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 veya üzeri Windows, Linux ve macOS üzerinde | Linux'ta: `fontconfig` kitaplığı, eğer önceden yüklü değilse |

Emin değilseniz, Windows'ta Aspose.Slides.NET'i, Linux ve macOS'ta Aspose.Slides.NET6.CrossPlatform'u kullanın. Alpine Linux'ta ve glibc'si 2.23 (x64) veya 2.39 (ARM64) sürümünden daha eski olan Linux sistemlerinde Aspose.Slides.NET'i tercih edin. [System Requirements](/slides/tr/net/system-requirements/) her paketin desteklediği platformları listeler.

## **.NET CLI ile Kurulum**

Bu adımlar Windows, Linux ve macOS'ta .NET SDK 6 veya üzeri ile çalışır. Bir konsol uygulaması oluşturun:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Ardından platformunuz için paketi ekleyin. Bir projeye sadece iki paketten birini ekleyin.

- Windows'ta: `dotnet add package Aspose.Slides.NET`
- Linux ve macOS'ta: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (Linux'ta, önce önkoşulunu yükleyin; bkz. [Linux](#linux))

Paketi test etmek için *Program.cs* içeriğini [Create Presentations](/slides/tr/net/create-presentation/) sayfasındaki ilk örnekle değiştirin ve `dotnet run` komutunu çalıştırın. *hello.pptx* dosyasını proje klasörüne kaydeder.

## **Windows**

### **Yöntem 1: NuGet Paket Yöneticisi'nden Aspose.Slides'i Yükleyin veya Güncelleyin**

1. Microsoft Visual Studio'yu açın.
2. Bir konsol uygulaması oluşturun ya da mevcut bir projeyi açın.
3. **Solution Explorer** içinde projeye sağ tıklayın ve **Manage NuGet Packages** seçeneğini seçin (veya **Project** > **Manage NuGet Packages** menüsüne gidin).
4. **Browse** altında *Aspose.Slides* arayın.
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. **Aspose.Slides.NET**'e tıklayın ve ardından **Install**'a tıklayın.  
   * Eğer Aspose.Slides'i zaten yüklediyseniz ve güncellemek istiyorsanız, bunun yerine **Update**'a tıklayın.

Paket indirildi ve projenizde referans olarak eklendi.

### **Yöntem 2: Paket Yöneticisi Konsolu üzerinden Aspose.Slides'i Yükleyin veya Güncelleyin**

Bu, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) paketini Paket Yöneticisi Konsolu üzerinden nasıl referans göstereceğinizdir:

1. Microsoft Visual Studio'yu açın.
2. Bir konsol uygulaması oluşturun ya da mevcut bir projeyi açın.
3. **Tools** > **NuGet Package Manager** > **Package Manager Console** menüsüne gidin.
![Opening the Package Manager Console](installation_2.png)
4. Bu komutu çalıştırın: `Install-Package Aspose.Slides.NET`
![Running the Install-Package command](installation_3.png)
En son sürüm projenize yüklendi.

**Installing Aspose.Slides.NET** mesajı pencerenin alt kısmında görünür.
![Installation progress in the Package Manager Console](installation_4.png)

İndirme tamamlandığında onay mesajları gösterilir. Paket, [Aspose EULA](https://about.aspose.com/legal/eula) altında dağıtılır.
![Installation confirmation messages](installation_5.png)

Aspose.Slides artık projenize eklenmiş ve referans gösterilmiştir.
![Aspose.Slides referenced in the project](installation_6.png)

Paketi güncellemek için Paket Yöneticisi Konsolu'nda `Update-Package Aspose.Slides.NET` komutunu çalıştırın.

## **Linux**

Yukarıdaki .NET CLI adımlarını kullanın. Paketi seçin ve dağıtımınızın paket yöneticisiyle önkoşulunu yükleyin. Debian ve Ubuntu'da:

- **Aspose.Slides.NET6.CrossPlatform**: `fontconfig` paketini kurun.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
```

- **Aspose.Slides.NET**: `libgdiplus` paketini kurun ve uygulamanız Aspose.Slides'i kullanmadan önce System.Drawing için Unix desteğini etkinleştirin.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
```

  Bu ifadeyi uygulamanızın başına, herhangi bir Aspose.Slides çağrısından önce ekleyin. Üst‑seviye bildirimleri olan bir *Program.cs* dosyasında, `using` yönergelerinden sonra koyun:

  ```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

  Bu paketi Alpine Linux'ta ve glibc'si Aspose.Slides.NET6.CrossPlatform için çok eski olan sistemlerde kullanın.

Sunumlarınızda kullanılan yazı tipleri veya uygun alternatifleri, metnin doğru görüntülenebilmesi için sistemde yüklü olmalıdır. [System Requirements](/slides/tr/net/system-requirements/) Alpine Linux'ta Aspose.Slides.NET'in ihtiyaç duyduğu paketleri, yazı tiplerini de içerecek şekilde açıklar.

## **macOS**

Yukarıdaki .NET CLI adımlarını **Aspose.Slides.NET6.CrossPlatform** paketiyle kullanın; bu paket Intel (x86_64) ve Apple silikon (ARM64) Mac'leri destekler:

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **SSS**

**Ücretsiz bir sürüm veya deneme sınırlaması var mı?**

Evet. Lisans olmadan, Aspose.Slides değerlendirme modunda çalışır: kaydettiği her slayda değerlendirme filigranı ekler ve sunumlardan okunan metni kısaltır. Bu sınırlamaları kaldırmak için geçerli bir [license](/slides/tr/net/licensing/) uygulayın.