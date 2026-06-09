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
description: "Aspose.Slides for .NET'in güven gereksinimleri, izinleri ve barındırma sınırlamaları hakkında bilgi edinin, böylece PPT, PPTX ve ODP işleyen uygulamaları sunucularda güvenli bir şekilde dağıtabilirsiniz."
---
{{% alert color="primary" %}} 

Tüm Aspose .NET bileşenleri, bazı işlemler (örneğin yazı tiplerini ayrıştırma) için zaman zaman kayıt defteri ayarlarına, sistem dosyalarına ve sanal dizinin dışındaki diğer konumlardaki dosyalara erişmeleri gerektiğinden Full Trust izin kümesini gerektirir. Ayrıca, Aspose .NET Bileşenleri, birçok durumda Full Trust izin kümesini zorunlu kılan temel .NET sistem sınıflarına dayanır. 

{{% /alert %}} 

Farklı şirketlerin birden çok uygulamasını barındıran İnternet Servis Sağlayıcıları genellikle Medium Trust güvenlik seviyesini uygular. .NET 2.0 senaryosunda, bu güvenlik seviyesi aşağıdaki kısıtlamaları getirir: 

- OleDbPermission mevcut değildir. Bu, ADO.NET yönetilen OLE DB veri sağlayıcısını kullanarak veritabanlarına erişemeyeceğiniz anlamına gelir.
- EventLogPermission mevcut değildir. Bu, Windows olay günlüğüne erişemeyeceğiniz anlamına gelir.
- ReflectionPermission mevcut değildir. Bu, yansıma (reflection) kullanamayacağınız anlamına gelir.
- RegistryPermission mevcut değildir. Bu, kayıt defterine erişemeyeceğiniz anlamına gelir.
- WebPermission kısıtlanmıştır. Bu, uygulamanızın yalnızca <trust> öğesinde tanımladığınız bir adresle veya adres aralığıyla iletişim kurabileceği anlamına gelir.
- FileIOPermission kısıtlanmıştır. Bu, yalnızca uygulamanızın sanal dizin hiyerarşisindeki dosyalara erişebileceğiniz anlamına gelir.

{{% alert color="primary" %}} 

Yukarıdaki nedenlerden dolayı, Aspose .NET bileşenleri yalnızca Full Trust izin kümesini sağlayan sunucularda kullanılabilir. 

{{% /alert %}}