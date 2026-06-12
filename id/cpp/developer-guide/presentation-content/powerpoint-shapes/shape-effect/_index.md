---
title: Terapkan Efek Bentuk pada Presentasi Menggunakan C++
linktitle: Efek Bentuk
type: docs
weight: 30
url: /id/cpp/shape-effect/
keywords:
- efek bentuk
- efek bayangan
- efek refleksi
- efek glow
- efek tepi lembut
- format efek
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Ubah file PPT dan PPTX Anda dengan efek bentuk lanjutan menggunakan Aspose.Slides untuk C++ — buat slide yang memukau dan profesional dalam hitungan detik."
---
## **Pendahuluan**

Sementara efek di PowerPoint dapat digunakan untuk menonjolkan sebuah bentuk, mereka berbeda dari [fills](/slides/id/cpp/shape-formatting/#gradient-fill) atau outline. Dengan menggunakan efek PowerPoint, Anda dapat membuat refleksi yang meyakinkan pada sebuah bentuk, menyebarkan cahaya pada bentuk, dll.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint menyediakan enam efek yang dapat diterapkan pada bentuk. Anda dapat menerapkan satu atau lebih efek pada sebuah bentuk. 

* Beberapa kombinasi efek terlihat lebih baik daripada yang lain. Untuk alasan ini, PowerPoint menyediakan opsi di bawah **Preset**. Opsi Preset pada dasarnya merupakan kombinasi dua atau lebih efek yang sudah terbukti terlihat bagus. Dengan memilih preset, Anda tidak perlu membuang waktu menguji atau menggabungkan efek yang berbeda untuk menemukan kombinasi yang tepat.

Aspose.Slides menyediakan properti dan metode di bawah kelas [EffectFormat](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.effect_format/) yang memungkinkan Anda menerapkan efek yang sama pada bentuk dalam presentasi PowerPoint.

## **Menerapkan Efek Bayangan**

Kode C++ ini menunjukkan cara menerapkan efek bayangan luar ([OuterShadowEffect](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) pada sebuah persegi panjang:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(System::Drawing::Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Menerapkan Efek Refleksi**

Kode C++ ini menunjukkan cara menerapkan efek refleksi pada sebuah bentuk:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(55);
reflectionEffect->set_BlurRadius(4);

pres->Save(u"reflection.pptx", SaveFormat::Pptx);
```

## **Menerapkan Efek Glow**

Kode C++ ini menunjukkan cara menerapkan efek glow pada sebuah bentuk:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(System::Drawing::Color::get_Magenta());
glowEffect->set_Radius(15);

pres->Save(u"glow.pptx", SaveFormat::Pptx);
```

## **Menerapkan Efek Soft Edges**

Kode C++ ini menunjukkan cara menerapkan soft edges pada sebuah bentuk:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(15);

pres->Save(u"softEdges.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apakah saya dapat menerapkan beberapa efek pada bentuk yang sama?**

Ya, Anda dapat menggabungkan berbagai efek, seperti bayangan, refleksi, dan glow, pada satu bentuk untuk menghasilkan tampilan yang lebih dinamis.

**Bentuk apa yang dapat saya beri efek?**

Anda dapat menerapkan efek pada berbagai bentuk, termasuk autoshapes, bagan, tabel, gambar, objek SmartArt, objek OLE, dan sebagainya.

**Apakah saya dapat menerapkan efek pada bentuk yang dikelompokkan?**

Ya, Anda dapat menerapkan efek pada bentuk yang dikelompokkan. Efek tersebut akan diterapkan pada seluruh grup.