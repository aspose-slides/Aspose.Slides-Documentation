---
title: Terapkan Efek Bentuk dalam Presentasi Menggunakan C++
linktitle: Efek Bentuk
type: docs
weight: 30
url: /id/cpp/shape-effect/
keywords:
- efek bentuk
- efek bayangan
- efek refleksi
- efek cahaya
- efek tepi lembut
- format efek
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Transformasikan file PPT dan PPTX Anda dengan efek bentuk lanjutan menggunakan Aspose.Slides untuk C++ — buat slide yang menarik dan profesional dalam hitungan detik."
---
## **Pengantar**

Sementara efek di PowerPoint dapat digunakan untuk menonjolkan sebuah bentuk, mereka berbeda dari [isi](/slides/id/cpp/shape-formatting/#gradient-fill) atau garis tepi. Dengan menggunakan efek PowerPoint, Anda dapat membuat refleksi yang meyakinkan pada sebuah bentuk, menyebarkan cahaya pada bentuk, dll.

![Efek Bentuk](shape-effect.png)

PowerPoint menyediakan enam efek yang dapat diterapkan pada bentuk. Anda dapat menerapkan satu atau lebih efek pada sebuah bentuk.

Beberapa kombinasi efek tampak lebih baik daripada yang lain. Untuk alasan ini, PowerPoint memiliki opsi di bawah **Preset**. Opsi Preset pada dasarnya merupakan kombinasi dari dua atau lebih efek yang diketahui cocok bersama. Dengan cara ini, dengan memilih preset, Anda tidak perlu membuang waktu untuk menguji atau menggabungkan efek yang berbeda demi menemukan kombinasi yang bagus.

Aspose.Slides menyediakan properti dan metode di dalam kelas [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) yang memungkinkan Anda menerapkan efek yang sama pada bentuk dalam presentasi PowerPoint.

## **Menerapkan Efek Bayangan**

Aspose.Slides untuk C++ mendukung bayangan luar dan dalam untuk bentuk. Anda dapat menyesuaikan warna, arah, jarak, dan radius blur mereka agar sesuai dengan desain presentasi Anda.

### **Menerapkan Bayangan Luar**

Gunakan bayangan luar untuk membuat kartu atau panel menonjol di atas latar belakang slide. Bayangan ini meluas di luar tepi bentuk, menciptakan kesan bahwa bentuk tersebut terangkat di atas slide. Sesuaikan warna, arah, jarak, dan radius blur untuk mencocokkan pencahayaan dan gaya templat Anda.

Kode C++ berikut menunjukkan cara menerapkan [efek bayangan luar](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) pada sebuah persegi panjang:
```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

presentation->Save(u"shadow_effect.pptx", SaveFormat::Pptx);
```

![Efek Bayangan](shadow_effect.png)

### **Menerapkan Bayangan Dalam**

Saat mereproduksi gaya visual templat, gunakan bayangan dalam untuk memberikan kartu atau panel tampilan terbenam. Bayangan luar meluas di luar bentuk dan membuatnya tampak terangkat, sementara bayangan dalam memberikan bayangan di bagian dalam tepinya.

Panggil [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), lalu konfigurasikan [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Nilai radius blur yang lebih besar menghasilkan tepi yang lebih lembut.

Contoh C++ ini membuat kartu biru muda dengan bayangan dalam abu-abu gelap dan menyimpannya sebagai file PPTX:
```cpp
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_LightBlue());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

shape->get_EffectFormat()->EnableInnerShadowEffect();
auto shadow = shape->get_EffectFormat()->get_InnerShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_DimGray());
shadow->set_Direction(225);
shadow->set_Distance(7);
shadow->set_BlurRadius(6);

presentation->Save(u"inner_shadow_effect.pptx", SaveFormat::Pptx);
```

![Persegi panjang biru muda dengan bayangan dalam](inner_shadow_effect.png)

Untuk menghapus bayangan dalam, panggil [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) pada format efek bentuk.

## **Menerapkan Efek Refleksi**

Untuk menerapkan efek refleksi di Aspose.Slides untuk C++, Anda dapat menambahkan refleksi seperti cermin pada bentuk, menyesuaikan parameter seperti jarak, transparansi, dan ukuran. Efek ini meningkatkan estetika presentasi Anda dengan memberikan bentuk tampilan yang lebih halus dan sophisticated. Mudah diimplementasikan dengan kode sederhana, memungkinkan penerapan cepat pada beberapa elemen untuk desain yang konsisten.

Kode C++ berikut menunjukkan cara menerapkan [efek refleksi](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) pada sebuah bentuk:
```cpp
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(40);
reflectionEffect->set_BlurRadius(2);

presentation->Save(u"reflection_effect.pptx", SaveFormat::Pptx);
```

![Efek Refleksi](reflection_effect.png)

## **Menerapkan Efek Glow**

Untuk menerapkan efek glow pada sebuah bentuk di Aspose.Slides untuk C++, Anda dapat menambahkan aura lembut dan bercahaya di sekitar bentuk, menyesuaikan properti seperti warna dan ukuran. Efek ini membantu membuat bentuk menonjol dan menambahkan elemen visual yang menarik dan mencolok pada presentasi Anda. Mudah diimplementasikan dengan kode minimal, meningkatkan tampilan keseluruhan slide Anda.

Kode C++ berikut menunjukkan cara menerapkan [efek glow](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) pada sebuah bentuk:
```cpp
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Magenta());
glowEffect->set_Radius(15);

presentation->Save(u"glow_effect.pptx", SaveFormat::Pptx);
```

![Efek Glow](glow_effect.png)

## **Menerapkan Efek Tepi Lembut**

Untuk menerapkan efek tepi lembut di Aspose.Slides untuk C++, Anda dapat membuat transisi halus dan kabur di sekitar tepi sebuah bentuk. Efek ini menambahkan tampilan yang lebih halus dan elegan, cocok untuk desain yang membutuhkan penampilan lembut dan halus. Anda dapat dengan mudah menyesuaikan parameter seperti radius untuk mencapai efek yang diinginkan pada berbagai bentuk dalam presentasi Anda.

Kode C++ berikut menunjukkan cara menerapkan [tepi lembut](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) pada sebuah bentuk:
```cpp
#include <DOM/Effects/ISoftEdge.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(8);

presentation->Save(u"soft_edges_effect.pptx", SaveFormat::Pptx);
```

![Efek Tepi Lembut](soft_edges_effect.png)

## **Menerapkan Efek Blur**

Gunakan blur bentuk untuk melunakkan isi dan garis tepi bentuk sekaligus tetap dapat diedit. Panggil [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) pada format efek bentuk. Radius diukur dalam poin (1/72 inci): gunakan nilai nonnegatif, dengan nilai yang lebih besar menghasilkan blur yang lebih kuat. Radius nol tidak mengubah tampilan.

Pengaturan [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) mengontrol batas tampak efek. Dengan `false`, blur dipotong pada batas asli yang digambar, termasuk garis tepi. Dengan `true`, blur dapat meluas di luar batas tersebut. Kedua pengaturan tidak mengubah posisi atau dimensi bentuk.

Perbandingan di bawah menggunakan isi, garis tepi, dan dimensi bentuk yang sama sepanjang contoh. Baris atas menggunakan `grow = false`; baris bawah menggunakan `grow = true`.

![Persegi panjang asli dibandingkan dengan radius blur 5 dan 15 poin, dengan grow dinonaktifkan dan diaktifkan](shape_blur_comparison.png)

Contoh C++ ini membuat persegi panjang oranye dengan garis tepi biru tua, menerapkan blur 5 poin, lalu memperbaruinya menjadi blur 15 poin dengan memanggil [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) lagi. Itu menyimpan kedua keadaan blur, kemudian memanggil [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) dan menyimpan bentuk tanpa blur.
```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 80.0f, 160.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
shape->get_LineFormat()->set_Width(8);

shape->get_EffectFormat()->SetBlurEffect(5, false);
presentation->Save(u"shape_blur_5.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->SetBlurEffect(15, true);
presentation->Save(u"shape_blur_15.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->DisableBlurEffect();
presentation->Save(u"shape_blur_removed.pptx", SaveFormat::Pptx);
```

Blur bentuk memengaruhi isi dan garis tepi secara bersamaan. Efek tepi lembut memudarkan tepi bentuk, sementara blur bayangan melunakkan hanya bayangan. Efek transformasi gambar beroperasi pada konten gambar; contoh ini menerapkan blur langsung pada format efek bentuk tanpa mengonversi bentuk menjadi gambar.

## **FAQ**

**Apakah saya dapat menerapkan beberapa efek pada bentuk yang sama?**

Ya, Anda dapat menggabungkan berbagai efek, seperti bayangan, refleksi, dan glow, pada satu bentuk untuk menciptakan tampilan yang lebih dinamis.

**Bentuk apa yang dapat saya terapkan efek?**

Anda dapat menerapkan efek pada berbagai bentuk, termasuk autoshape, diagram, tabel, gambar, objek SmartArt, objek OLE, dan lainnya.

**Apakah saya dapat menerapkan efek pada bentuk yang dikelompokkan?**

Ya, Anda dapat menerapkan efek pada bentuk yang dikelompokkan. Efek tersebut akan diterapkan pada seluruh grup.