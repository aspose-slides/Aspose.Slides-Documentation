---
title: Kurulum
type: docs
weight: 70
url: /tr/net/installation/
keywords:
- Aspose.Slides kurulum
- Aspose.Slides indirin
- Aspose.Slides kullanın
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
description: "Aspose.Slides for .NET'i hızlı bir şekilde nasıl kuracağınızı öğrenin. Adım adım kılavuz, sistem gereksinimleri ve kod örnekleri — bugün PowerPoint sunumlarıyla çalışmaya başlayın!"
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET'i Windows ve macOS'ta nasıl kuracağınızı açıklar. NuGet tabanlı kurulum üzerine odaklanır ve kütüphaneyi bir Visual Studio projesine Windows'ta NuGet Paket Yöneticisi veya Paket Yöneticisi Konsolu aracılığıyla nasıl ekleyeceğinizi gösterir. Ayrıca paketi nasıl güncelleyeceğinizi ve gerektiğinde ön sürüm derlemelerini nasıl kuracağınızı anlatır.

## **Windows**

NuGet, Aspose API'lerini .NET için PC'lerde indirme ve kurma konusunda en kolay yolu sunar. 

### **Yöntem 1: Aspose.Slides'i NuGet Paket Yöneticisi ile Kurun veya Güncelleyin**

1. Microsoft Visual Studio'yu açın. 
2. Basit bir konsol uygulaması oluşturun veya mevcut bir projeyi açın. 
3. **Tools** > **NuGet package manager** üzerinden ilerleyin.
4. **Browse** altında, metin alanına *Aspose Slides* yazın ve arayın. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. **Aspose.Slides.NET**'e tıklayın ve ardından **Install** düğmesine tıklayın. 
   * Aspose.Slides'i güncellemek istiyorsanız — zaten kurulu olduğunu varsayarak— bunun yerine **Update**'a tıklayın. 

Seçilen API indirildikten sonra projenize referans olarak eklenir.

### **Yöntem 2: Aspose.Slides'i Paket Yöneticisi Konsolu ile Kurun veya Güncelleyin**

Paket yöneticisi konsolu aracılığıyla [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) referans gösterme şekli şöyle:

1. Microsoft Visual Studio'yu açın. 
2. Basit bir konsol uygulaması oluşturun veya mevcut bir projeyi açın. 
3. **Tools** > **Library Package Manager** > **Package Manager Console** üzerinden ilerleyin. 
![todo:image_alt_text](installation_2.png)
4. Bu komutu çalıştırın: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
En son tam sürüm uygulamanıza kurulacaktır. 

* Alternatif olarak, komuta `-prerelease` sonekini ekleyerek en son sürümün (hotfix'ler dahil) kurulmasını da belirtebilirsiniz. 

**Installing Aspose.Slides.NET** ipucu pencerede alt kısma doğru görünür. 
![todo:image_alt_text](installation_4.png)

İndirme tamamlandığında bazı onay mesajları görmelisiniz. 

[Aspose EULA](https://about.aspose.com/legal/eula) ile tanışık değilseniz, URL'de belirtilen lisansı okumanız faydalı olabilir. 
![todo:image_alt_text](installation_5.png)

Uygulamanızda, Aspose.Slides'in başarıyla eklendiğini ve referans verildiğini görmelisiniz. 
![todo:image_alt_text](installation_6.png)

Paket Yöneticisi Konsolu'nda, Aspose.Slides paketinin güncellemelerini kontrol etmek için `Update-Package Aspose.Slides.NET` komutunu çalıştırabilirsiniz. Güncellemeler (varsa) otomatik olarak kurulur. En son sürümü güncellemek için `-prerelease` sonekini de kullanabilirsiniz.

#### **Paylaşılan Sunucu Ortamında Çalıştırma Düşünceleri**
Tüm Aspose .NET bileşenlerini **Full Trust** izin setiyle çalıştırmanızı şiddetle öneririz; çünkü Aspose bileşenleri bazen kayıt defteri ayarlarına ve sanal dizinden farklı konumlardaki dosyalara erişim gerektirir—örneğin, fontları okurken.

Ayrıca, Aspose.NET bileşenleri temel .NET sistem sınıflarına dayanır ve bu sınıfların bazıları belirli durumlarda Full Trust iznine ihtiyaç duyar.

Farklı şirketlerden çoklu uygulamaları barındıran Internet Service Provider'lar genellikle Medium Trust güvenlik seviyesini zorunlu kılar. .NET 2.0 durumunda, bu güvenlik seviyesi Aspose.Slides'in işlemlerini etkileyebilecek kısıtlamalara neden olabilir:

- **RegistryPermission** mevcut değildir. Bu, belge render ederken yüklü fontları listelemek için gereken kayıt defterine erişemeyeceğiniz anlamına gelir.
- **FileIOPermission** kısıtlıdır. Bu, yalnızca uygulamanızın sanal dizin hiyerarşisindeki dosyalara erişebileceğiniz anlamına gelir. Bu da dışa aktarım işlemleri sırasında fontların okunamama ihtimalini ortaya çıkarır.

Yukarıdaki nedenlerden dolayı, Aspose.Slides'i **Full Trust** izinleriyle çalıştırmanızı şiddetle öneririz. **Medium trust** kullanırsanız, bazı kütüphane özelliklerinin (örneğin render) belirli görevlerde çalışmayabileceği tutarsızlıklar yaşayabilirsiniz. 

## **macOS**

NuGet, macOS'ta .NET için Aspose.Slides'i indirme ve kurma konusunda en kolay yolu sunar. 

**Önkoşulu Kurun**

`System.Drawing` ad alanı macOS'ta farklı çalıştığından mono-libgdiplus kurmanız gerekir.

> .NET 5 ve önceki sürümlerde, [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet paketi Windows, Linux ve macOS'ta çalışır. Ancak bazı platform farklılıkları vardır. Linux ve macOS'ta GDI+ işlevselliği [libgdiplus](https://www.mono-project.com/docs/gui/libgdiplus/) kütüphanesi tarafından uygulanır. Bu kütüphane çoğu Linux dağıtımında varsayılan olarak kurulu değildir ve Windows ve macOS'taki GDI+ işlevselliğinin tamamını desteklemez. Ayrıca libgdiplus'un tamamen bulunmadığı platformlar da vardır. Linux ve macOS'ta System.Drawing.Common paketindeki türleri kullanmak için libgdiplus'u ayrı olarak kurmalısınız. Daha fazla bilgi için [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) veya [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) sayfalarına bakın.

Mac'inizde mono-libgdiplus'u ayrı olarak kurmak için .NET belgelerindeki [bu makale](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) adresine bakın. 

### **Aspose.Slides'i Kurun**

1. Visual Studio'yu açın. 
2. Basit bir konsol uygulaması oluşturun veya mevcut bir projeyi açın.
3. **Project** > **Manage NuGet Packages...** üzerinden ilerleyin.
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Metin alanına *Aspose.Slides* yazın. 
5. **Aspose.Slides for .NET**'e tıklayın ve ardından **Add Package**'a tıklayın. 
6. Basit bir kod parçacığı ekleyin.
   * [Bu sayfada](/slides/tr/net/create-presentation/) kodu kopyalayabilirsiniz.
7. Uygulamayı çalıştırın.
8. Projenizin *folder/bin/Debug/presentation_file_name* klasörünü açın.

## **SSS**

**Ücretsiz bir sürüm ya da deneme kısıtlaması var mı?**

Evet, varsayılan olarak Aspose.Slides değerlendirme modunda çalışır, bu da filigran ekler ve başka sınırlamalar olabilir. Kısıtlamaları kaldırmak için geçerli bir [lisans](/slides/tr/net/licensing/) uygulamanız gerekir.