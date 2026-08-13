---
title: Deklarasyon
type: docs
weight: 110
url: /tr/net/declaration/
keywords:
- deklarasyon
- bileşenler
- Full Trust izni
- kayıt defteri ayarları
- sistem dosyaları
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET güven gereksinimleri, izinler ve barındırma sınırlamaları hakkında bilgi edinin, böylece PPT, PPTX ve ODP işleyen uygulamaları sunucularda güvenle dağıtabilirsiniz."
---
{{% alert color="info" %}} 

Tüm Aspose .NET bileşenleri Full Trust izin setini gerektirir çünkü bazen belirli işlemler (örneğin font ayrıştırma) için kayıt defteri ayarlarına, sistem dosyalarına ve sanal dizinin dışındaki diğer konumlardaki dosyalara erişmeleri gerekir. Ayrıca Aspose .NET Bileşenleri, birçok durumda Full Trust izin setini gerektiren temel .NET sistem sınıflarına dayanır. 

{{% /alert %}} 

Internet Service Providers, which host multiple applications from different companies, mostly enforce the Medium Trust security level. In a .NET 2.0 case, such a security level applies these constraints: 

- OleDbPermission mevcut değil. Bu, veritabanlarına erişmek için ADO.NET yönetilen OLE DB veri sağlayıcısını kullanamayacağınız anlamına gelir.
- EventLogPermission mevcut değil. Bu, Windows olay günlüğüne erişemeyeceğiniz anlamına gelir.
- ReflectionPermission mevcut değil. Bu, yansıma kullanamayacağınız anlamına gelir.
- RegistryPermission mevcut değil. Bu, kayıt defterine erişemeyeceğiniz anlamına gelir.
- WebPermission kısıtlıdır. Bu, uygulamanızın yalnızca <trust> öğesinde tanımladığınız bir adresle veya adres aralığıyla iletişim kurabileceği anlamına gelir.
- FileIOPermission kısıtlıdır. Bu, yalnızca uygulamanızın sanal dizin hiyerarşisindeki dosyalara erişebileceğiniz anlamına gelir.

{{% alert color="info" %}} 

Yukarıdaki nedenlerden dolayı Aspose .NET bileşenleri yalnızca Full Trust izin setini veren sunucularda kullanılabilir. 

{{% /alert %}}