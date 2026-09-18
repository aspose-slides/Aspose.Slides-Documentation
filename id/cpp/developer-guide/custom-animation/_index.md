---
title: Buat dan Modifikasi Perilaku Animasi Kustom dalam C++
linktitle: Animasi Kustom
type: docs
weight: 151
url: /id/cpp/custom-animation/
keywords:
- animasi kustom
- perilaku animasi
- jalur gerak
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Buat, periksa, dan modifikasi perilaku animasi kustom serta jalur gerak yang dapat diedit dalam presentasi PowerPoint dengan Aspose.Slides untuk C++."
---
## **Gambaran Umum**

Perilaku animasi kustom memungkinkan Anda mengontrol operasi individu dalam sebuah efek animasi, seperti mengubah warna, memutar bentuk, atau mengikuti jalur gerak yang dapat diedit. Panduan ini menunjukkan cara membuat dan menggabungkan perilaku, mengonfigurasi waktu mereka, memeriksa dan memodifikasi animasi yang ada, serta memverifikasi bahwa propertinya tetap ada setelah menyimpan dan membuka kembali presentasi.

Untuk efek yang telah ditentukan dan pemicu klik, lihat [Shape Animation](/slides/id/cpp/shape-animation/).

## **Memahami Model Animasi**

Animasi disusun sebagai **Timeline → Sequence → Effect → Behaviors**:

- [get_Timeline](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslide/get_timeline/) pada slide berisi urutan utama dan urutan interaktif.
- [ISequence](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/isequence/) berisi efek, yang mungkin menargetkan bentuk yang berbeda.
- [IEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/) mengidentifikasi bentuk target, preset, subtipe, dan waktu efek.
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/get_behaviors/) berisi operasi yang mengimplementasikan efek: mengubah warna, memindahkan, memutar, mengatur properti, dan sebagainya.

## **Buat Perilaku Individual**

Panggil [ISequence::AddEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/isequence/addeffect/) untuk membuat efek dan mengakses koleksi [get_Behaviors](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/get_behaviors/)‑nya. Sebuah preset dapat mengisi koleksi ini secara otomatis. Pertahankan operasinya saat memperluas preset, atau gunakan [Clear](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehaviorcollection/clear/) ketika memang menggantinya.

[IBehaviorFactory](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehaviorfactory/) membuat delapan tipe perilaku yang diilustrasikan di bawah. Gerakan dibahas dalam [Build a Motion Path](#build-a-motion-path). Setiap contoh pembuatan adalah kode mandiri yang dapat dijalankan di dalam sebuah fungsi; contoh pengeditan selanjutnya menyebutkan berkas output yang digunakannya.

### **Rotasi**

Gunakan [CreateRotationEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) untuk membuat rotasi. [get_By](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/irotationeffect/get_by/) menentukan sudut relatif dalam derajat; [get_From](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/irotationeffect/get_from/) dan [get_To](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/irotationeffect/get_to/) menentukan titik akhir.

Contoh dimulai dengan efek Spin, mengganti operasi presetnya dengan satu perilaku rotasi, dan memberikan operasi tersebut durasi dua detik. Sudut relatif 90 derajat menyatakan seperempat putaran dari orientasi awal bentuk, sehingga tidak diperlukan sudut awal yang eksplisit.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto rotation = factory->CreateRotationEffect();
rotation->set_By(90.0f);
rotation->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(rotation);

presentation->Save(u"rotation.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`rotation.pptx` berisi satu bentuk dan satu perilaku rotasi. Koleksi, waktu, dan contoh pengeditan rotasi di bawah menggunakan berkas ini.

### **Skala**

Gunakan [CreateScaleEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) dengan persentase X/Y: [get_From](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/iscaleeffect/get_from/) dan [get_To](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/iscaleeffect/get_to/) menjelaskan ukuran awal dan akhir, sementara [get_By](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/iscaleeffect/get_by/) menjelaskan perubahan relatif. Di sini, 100 berarti ukuran asli.

Contoh memperbesar kedua dimensi dari 100 % ke 125 % selama dua detik. Menggunakan persentase horizontal dan vertikal yang sama menjaga proporsi bentuk; persentase yang berbeda akan meregangkan satu dimensi lebih dari yang lain.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_From(PointF(100, 100));
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(scale);

presentation->Save(u"scale.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Warna**

Gunakan [CreateColorEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) untuk mengubah isian dari biru ke jingga. [get_From](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/icoloreffect/get_from/) dan [get_To](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/icoloreffect/get_to/) adalah warna; [get_By](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/icoloreffect/get_by/) adalah offset warna. [IBehavior::get_Properties](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehavior/get_properties/) mengidentifikasi atribut yang dianimasikan.

Isian padat bentuk diinisialisasi ke biru, cocok dengan warna awal animasi. Memilih atribut isian‑warna memberi tahu perilaku bagian mana dari bentuk yang diubah; hanya titik akhir warna tidak mengidentifikasi atribut tersebut. Efek yang disimpan menggambarkan transisi dua detik ke jingga.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IColorEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/FillType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto color = factory->CreateColorEffect();
color->get_Properties()->Add(BehaviorProperty::get_FillColor()->get_Value());
color->get_From()->set_Color(Color::get_Blue());
color->get_To()->set_Color(Color::get_Orange());
color->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(color);

presentation->Save(u"color.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Filter**

Gunakan [CreateFilterEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) untuk memilih wipe. [get_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ifiltereffect/get_subtype/), dan [get_Reveal](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) menentukan filter, arah, dan apakah menampilkan atau menyembunyikan bentuk.

Contoh ini mengonfigurasi wipe dua detik yang menampilkan bentuk menggunakan subtipe arah kanan. Pengaturan filter termasuk dalam perilaku di dalam efek, sehingga dikonfigurasi setelah operasi asli preset dihapus.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/FilterEffectRevealType.h>
#include <DOM/Animation/FilterEffectSubtype.h>
#include <DOM/Animation/FilterEffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IFilterEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto filter = factory->CreateFilterEffect();
filter->set_Type(FilterEffectType::Wipe);
filter->set_Subtype(FilterEffectSubtype::Right);
filter->set_Reveal(FilterEffectRevealType::In);
filter->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(filter);

presentation->Save(u"filter.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Properti**

Gunakan [CreatePropertyEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) untuk menganimasikan opacity. [get_From](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ipropertyeffect/get_to/), dan [get_By](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ipropertyeffect/get_by/) adalah string yang diinterpretasikan menggunakan [get_ValueType](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) dan [get_CalcMode](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/). Pilih titik akhir atau offset relatif daripada mengatur ketiganya sekaligus.

Di sini, atribut yang dipilih adalah opacity, dan string numerik mewakili perubahan dari 25 % opacity ke opacity penuh. Interpolasi linear menggambarkan perubahan bertahap antara nilai‑nilai tersebut. Saat menyesuaikan contoh ini untuk atribut lain, pilih tipe nilai dan nilai titik akhir yang sesuai dengan atribut tersebut.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IPropertyEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/PropertyCalcModeType.h>
#include <DOM/Animation/PropertyValueType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto property = factory->CreatePropertyEffect();
property->get_Properties()->Add(BehaviorProperty::get_StyleOpacity()->get_Value());
property->set_ValueType(PropertyValueType::Number);
property->set_CalcMode(PropertyCalcModeType::Linear);
property->set_From(u"0.25");
property->set_To(u"1");
property->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(property);

presentation->Save(u"property.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Set**

Gunakan [CreateSetEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) untuk menetapkan visibilitas melalui [get_To](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/iseteffect/get_to/). Perilaku set tidak melakukan interpolasi antara titik akhir.

Contoh memilih atribut visibilitas dan menetapkan string `visible` ketika perilaku dijalankan. Di C++, balut string sebagai objek sebelum menugaskannya ke perilaku set. Persegi sudah terlihat dalam presentasi minimal ini, sehingga penugasan mungkin tidak menghasilkan perubahan visual yang jelas sendiri. Operasi semacam ini berguna sebagai bagian dari efek yang lebih besar yang juga mengontrol kapan bentuk menjadi tersembunyi atau terlihat.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISetEffect.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto set = factory->CreateSetEffect();
set->get_Properties()->Add(BehaviorProperty::get_StyleVisibility()->get_Value());
auto visibility = ObjectExt::Box<String>(u"visible");
set->set_To(visibility);

effect->get_Behaviors()->Add(set);

presentation->Save(u"set.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Command**

Gunakan [CreateCommandEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) dan konfigurasikan [get_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/icommandeffect/get_commandstring/), dan [get_ShapeTarget](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/). Letakkan rekaman WAV bernama `sample.wav` di direktori kerja. Contoh ini menyematkannya dengan [AddAudioFrameEmbedded](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) dan menambahkan perintah play ke frame audio.

Frame audio adalah target efek sekaligus target perintah. Ini menghubungkan permintaan play ke rekaman yang disematkan; string perintah saja tidak mengidentifikasi objek media mana yang harus dikontrol. Efek dikonfigurasikan untuk dimulai dengan klik selama slideshow.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/CommandEffectType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/ICommandEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = IO::File::OpenRead(u"sample.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto command = factory->CreateCommandEffect();
command->set_Type(CommandEffectType::Call);
command->set_CommandString(u"play");
command->set_ShapeTarget(audioFrame);

effect->get_Behaviors()->Add(command);

presentation->Save(u"command.pptx", SaveFormat::Pptx);

audioStream->Close();

presentation->Dispose();
```

Menyimpan menyimpan perintah dalam `command.pptx`; tidak memutar rekaman. Pemutaran membutuhkan pemutar slideshow yang mendukung perintah dan target medianya.

## **Kelola Koleksi Perilaku**

[IBehaviorCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehaviorcollection/) mendukung [Add](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehaviorcollection/remove/), dan [RemoveAt](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehaviorcollection/removeat/). Contoh ini membuka `rotation.pptx`, menambahkan skala, memindahkannya sebelum rotasi, dan menghapus rotasi. Menghapus dan menyisipkan kembali objek yang sama mengubah posisi yang disimpan tanpa membuat salinan.

Urutan penyuntingan mengubah koleksi dari rotasi‑skala menjadi skala‑rotasi, lalu menjadi hanya skala. Indeks mengacu pada koleksi saat ini, jadi penghapusan menggunakan indeks baru rotasi setelah penataan ulang. Enumerasi akhir mengonfirmasi perilaku mana yang akan disimpan.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto behaviors = effect->get_Behaviors();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

behaviors->Add(scale);

behaviors->Remove(scale);
behaviors->Insert(0, scale);
behaviors->RemoveAt(1);

for (auto behavior : behaviors)
    Console::WriteLine(behavior->GetType().get_Name());

presentation->Save(u"collection-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Outputnya adalah `ScaleEffect`: hanya skala yang tersisa. Urutan koleksi tidak, dengan sendirinya, menjadwalkan perilaku satu demi satu. Bersihkan koleksi hanya ketika mengganti semua operasinya.

## **Konfigurasikan Waktu Perilaku**

[IBehavior::get_Timing](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehavior/get_timing/) menampilkan [ITiming](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/), terpisah dari [IEffect::get_Timing](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/get_timing/). Waktu efek menjadwalkan efek yang membungkus; waktu perilaku menjelaskan operasi di dalamnya.

### **Atur Durasi, Penundaan, Pengulangan, dan Akselerasi**

Buka `rotation.pptx` dan atur [get_Duration](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/get_duration/) serta [get_TriggerDelayTime](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) dalam detik, kemudian konfigurasikan [get_RepeatCount](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/get_repeatcount/). [get_Accelerate](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/get_accelerate/) dan [get_Decelerate](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/get_decelerate/) adalah pecahan dari durasi; pertahankan jumlahnya tidak lebih dari 1.

Berkas masukan adalah yang dibuat pada contoh rotasi, dimana perilaku pertama diketahui berupa rotasi. Contoh ini hanya mengubah waktu perilaku tersebut; sudut 90 derajat tetap utuh. Memisahkan sudut dan waktu memudahkan penyesuaian kecepatan tanpa harus membangun ulang animasi.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto rotation = ExplicitCast<IRotationEffect>(effect->get_Behaviors()->idx_get(0));
rotation->get_Timing()->set_Duration(2.0f);
rotation->get_Timing()->set_TriggerDelayTime(0.5f);
rotation->get_Timing()->set_RepeatCount(3.0f);
rotation->get_Timing()->set_Accelerate(0.2f);
rotation->get_Timing()->set_Decelerate(0.2f);

presentation->Save(u"timing.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Perilaku menggunakan durasi dua detik, penundaan setengah detik, dan jumlah pengulangan 3. 20 % pertama dan terakhir dari durasinya digunakan untuk akselerasi dan deselerasi.

Kebijakan pengulangan lain termasuk [get_RepeatDuration](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), dan [get_RepeatUntilNextClick](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/); pilih satu kebijakan daripada mengaktifkan semuanya sekaligus. [get_AutoReverse](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/itiming/get_autoreverse/) memutar animasi mundur setelah putaran maju. Akselerasi dan deselerasi berlaku untuk perubahan kontinu, bukan untuk penetapan diskrit atau perintah.

## **Bangun Jalur Gerak**

Gunakan [CreateMotionEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) untuk membuat gerakan. [get_From](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/imotioneffect/get_to/), dan [get_By](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/imotioneffect/get_by/) menjelaskan koordinat atau offset berbasis persentase. Untuk rute yang dapat diedit, buat [MotionPath](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/motionpath/) dan tetapkan ke [IMotionEffect::get_Path](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/imotioneffect/get_path/). [IMotionPath](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/imotionpath/) menyimpan perintah jalur.

[MotionCommandPathType](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/motioncommandpathtype/) memilih operasi:

| Perintah | Titik | Makna |
| --- | --- | --- |
| MoveTo | One | Menetapkan posisi awal. |
| LineTo | One | Pindah sepanjang segmen lurus ke titik akhir. |
| CurveTo | Three | Mengikuti kurva kubik yang didefinisikan oleh dua titik kontrol dan satu titik akhir. |
| CloseLoop | None | Kembali ke posisi awal. |
| End | None | Menyelesaikan jalur. |

[MotionPathPointsType](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/motionpathpointstype/) menjelaskan karakteristik penyuntingan titik, seperti sudut atau titik halus. Ini tidak menggantikan tipe perintah. Gunakan tipe titik kurva untuk contoh kurva di bawah, dan tipe titik sudut untuk segmen lurus.

Koordinat jalur dinormalisasi ke dimensi slide: perpindahan X sebesar 0.25 mewakili seperempat lebar slide, bukan 0.25 poin. Y positif mengalir ke bawah. Perintah absolut menentukan posisi dalam sistem koordinat jalur; perintah relatif menentukan offset dari posisi saat ini. Ini terpisah dari [get_Origin](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/imotioneffect/get_origin/), yang memilih kerangka referensi jalur, dan [get_PathEditMode](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/), yang mengendalikan bagaimana jalur bergerak ketika bentuk dipindahkan.

### **Buat Jalur Lurus**

Buat perilaku gerak dengan titik awal, satu segmen lurus, dan perintah akhir. [IMotionPath::Add](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/imotionpath/add/) menerima tipe perintah, titik‑titiknya, tipe titik, dan flag koordinat relatif.

Perintah awal menetapkan (0, 0), dan garis berakhir di (0.25, 0), memberikan rute perpindahan horizontal seperempat lebar slide. Perintah akhir tidak memiliki koordinat titik. Setelah jalur ditetapkan, menambahkan perilaku gerak ke efek menghubungkan rute tersebut ke persegi panjang.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionOriginType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto motion = factory->CreateMotionEffect();
motion->set_Origin(MotionOriginType::Layout);
motion->get_Timing()->set_Duration(2.0f);

auto path = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0, 0) });
path->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto linePoints = MakeArray<PointF>({ PointF(0.25f, 0) });
path->Add(MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
auto endPoints = MakeArray<PointF>(0);
path->Add(MotionCommandPathType::End, endPoints, MotionPathPointsType::None, false);

motion->set_Path(path);
effect->get_Behaviors()->Add(motion);

presentation->Save(u"motion.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion.pptx` berisi satu perilaku gerak dengan tiga perintah jalur. Contoh penyuntingan berkas berikut menggunakan struktur yang diketahui ini.

### **Bandingkan Koordinat Absolut dan Relatif**

Kedua objek jalur ini menggambarkan rute yang sama. Perintah absolut berakhir di (0.3, 0.1); perintah relatif menambahkan (0.1, 0.1) ke posisi saat ini, menjadi (0.2, 0).

Kedua jalur memulai pada posisi yang sama. Untuk garis relatif, tambahkan offset X dan Y ke posisi saat ini untuk memperoleh titik akhir; untuk garis absolut, baca titik akhir secara langsung. Mengubah flag tanpa mengonversi koordinat akan menghasilkan rute yang berbeda.

```cpp
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::Drawing;

auto absolutePath = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
absolutePath->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto absoluteEndPoints = MakeArray<PointF>({ PointF(0.3f, 0.1f) });
absolutePath->Add(MotionCommandPathType::LineTo, absoluteEndPoints, MotionPathPointsType::Corner, false);

auto relativePath = MakeObject<MotionPath>();
auto relativeStartPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
relativePath->Add(MotionCommandPathType::MoveTo, relativeStartPoints, MotionPathPointsType::Auto, false);
auto relativeOffsets = MakeArray<PointF>({ PointF(0.1f, 0.1f) });
relativePath->Add(MotionCommandPathType::LineTo, relativeOffsets, MotionPathPointsType::Corner, true);
```

Terapkan salah satu jalur ke perilaku gerak untuk menggunakannya dalam presentasi. Argumen Boolean terakhir memilih koordinat relatif untuk perintah itu.

### **Ganti Garis dengan Kurva**

Buka `motion.pptx` dan ganti perintah garisnya dengan kurva kubik. Sediakan dua titik kontrol terlebih dahulu, diikuti oleh titik akhir.

Posisi awal disediakan oleh perintah sebelumnya. Dua titik pertama membentuk kurva, sementara titik ketiga adalah tujuan kurva; mereka bukan tiga tujuan berurutan. Memperbarui tipe perintah, tipe penyuntingan titik, dan array titik bersamaan menjaga segmen konsisten dengan geometri barunya.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
path->idx_get(1)->set_CommandType(MotionCommandPathType::CurveTo);
path->idx_get(1)->set_PointsType(MotionPathPointsType::CurveSmooth);
auto curvePoints = MakeArray<PointF>({ PointF(0.1f, 0), PointF(0.2f, 0.1f), PointF(0.3f, 0.1f) });
path->idx_get(1)->set_Points(curvePoints);

presentation->Save(u"curve.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Jalur dalam `curve.pptx` masih memiliki tiga perintah; perintah tengah kini mendefinisikan kurva.

## **Periksa dan Sunting Jalur yang Disimpan**

Setiap [IMotionCmdPath](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/imotioncmdpath/) menampilkan [get_Points](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/), dan [get_IsRelative](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/). Contoh berikut menggunakan jalur tiga‑perintah yang diketahui dalam `motion.pptx`. Untuk masukan arbitrer, temukan efek yang dimaksud dan periksa tipe perintah serta jumlah titik sebelum menyunting berdasarkan indeks.

### **Baca Perintah dan Koordinat**

Baca jalur tanpa mengubahnya. Perintah end dan close‑loop tidak memerlukan titik, jadi izinkan array titik null.

Output mencocokkan setiap perintah dengan flag koordinat relatifnya sebelum menuliskan titik‑titiknya. Ini memungkinkan Anda membedakan titik akhir dari offset sebelum memodifikasi jalur. Kurva akan menampilkan tiga titik, sedangkan garis lurus dalam berkas ini hanya menampilkan satu.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
for (auto segment : path)
{
    Console::WriteLine(u"{0}, relative: {1}", segment->get_CommandType(), segment->get_IsRelative());
    if (segment->get_Points() != nullptr)
        for (auto point : segment->get_Points())
            Console::WriteLine(u"X={0}, Y={1}", point.get_X(), point.get_Y());
}

presentation->Dispose();
```

Daftar berisi titik awal, garis absolut yang berakhir di (0.25, 0), dan perintah end.

### **Ubah Titik Akhir**

Buka `motion.pptx` dan ganti array titik garis untuk memindahkan titik akhirnya.

Dalam berkas masukan, indeks 0 adalah perintah awal dan indeks 1 adalah garis. Mengganti satu titik garis mengubah tujuan tanpa mengubah tipe perintah, waktu, atau posisi dalam koleksi. Karena perintah menggunakan koordinat absolut, pasangan baru menentukan posisi, bukan offset yang ditambahkan.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));
auto endpointPoints = MakeArray<PointF>({ PointF(0.4f, 0.1f) });
motion->get_Path()->idx_get(1)->set_Points(endpointPoints);

presentation->Save(u"motion-endpoint.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Garis dalam `motion-endpoint.pptx` berakhir di (0.4, 0.1); berkas asli tidak berubah.

### **Ganti Segmen**

Gunakan [Insert](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/imotionpath/insert/) dan [RemoveAt](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/imotionpath/removeat/) untuk mengganti garis dalam `motion.pptx`. Penyisipan memindahkan garis lama ke indeks 2.

Ini mendemonstrasikan penggantian objek perintah alih‑alih menyunting koordinatnya yang ada. Setelah penyisipan, koleksi sementara berisi perintah awal, garis baru, garis lama, dan perintah end. Menghapus indeks 2 membuang garis lama dan meninggalkan rute baru di tempat.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
auto linePoints = MakeArray<PointF>({ PointF(0.2f, 0.1f) });
path->Insert(1, MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
path->RemoveAt(2);

presentation->Save(u"motion-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Jalur yang disimpan masih memiliki tiga perintah, dengan garis baru berakhir di (0.2, 0.1) dan perintah end terakhir.

## **Ubah dan Verifikasi Perilaku yang Ada**

Ketika indeks perilaku tidak diketahui, pilih berdasarkan tipe. Contoh ini membuka `rotation.pptx`, menemukan [IRotationEffect](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/irotationeffect/), mengubah sudut, dan memeriksa nilai yang disimpan setelah membuka kembali.

Pemeriksaan tipe memungkinkan loop melewatkan perilaku yang bukan rotasi. Muatan kedua membaca berkas yang disimpan ke objek presentasi terpisah, sehingga perbandingan memeriksa data yang dipertahankan, bukan nilai yang masih berada di memori. Contoh ini tetap mengasumsikan efek yang diketahui berada pertama dalam urutan utama; memilih perilaku berdasarkan tipe tidak menemukan efek yang tepat dalam presentasi apa pun.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <cmath>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : effect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        rotation->set_By(180.0f);
}

presentation->Save(u"rotation-edited.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"rotation-edited.pptx");
auto savedEffect = reopened->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : savedEffect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        Console::WriteLine(u"Rotation preserved: {0}", std::abs(rotation->get_By() - 180.0f) < 0.001f);
}

presentation->Dispose();
reopened->Dispose();
```

Outputnya adalah `Rotation preserved: True`. Terapkan pola pemeriksaan tipe yang sama pada perilaku lain. Untuk pemeriksaan pelestarian lengkap, bandingkan bentuk target, efek, tipe dan urutan perilaku, waktu, serta perintah jalur. Gunakan toleransi numerik untuk nilai floating‑point. Untuk presentasi dengan tata letak animasi yang tidak diketahui, lihat [Read Shape Animations](/slides/id/cpp/shape-animation/#read-shape-animations) untuk penelusuran urutan utama dan interaktif.

## **Urutan Perilaku, Preset, dan Pemutaran**

Urutan dalam [IBehaviorCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehaviorcollection/) adalah urutan tersimpan operasi dalam sebuah efek. Itu bukan playlist di mana setiap perilaku secara otomatis menunggu perilaku sebelumnya. Waktu dan efek yang membungkus menentukan penjadwalan. Perilaku dapat saling tumpang‑tindih, dan operasi pada properti yang sama dapat berinteraksi melalui [get_Additive](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehavior/get_additive/) dan [get_Accumulate](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ibehavior/get_accumulate/). Jangan gunakan penataan ulang koleksi saja untuk menjadwalkan “pindah, lalu putar”; gunakan waktu eksplisit atau efek terpisah seperti yang dijelaskan dalam [Shape Animation](/slides/id/cpp/shape-animation/).

[IEffect::get_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/get_type/) dan [IEffect::get_Subtype](https://reference.aspose.com/slides/id/cpp/aspose.slides.animation/ieffect/get_subtype/) mendeskripsikan presetnya. Mereka bukan deskripsi lengkap dari pohon perilaku yang telah diedit. Pilih preset dan subtype sebelum menyesuaikan perilaku: mengubah preset dapat membangun kembali koleksi dan membuang operasi kustom Anda. Misalnya, mengubah efek Spin yang disesuaikan menjadi Fade dapat menggantikan perilaku rotasi dengan perilaku set dan filter. Periksa kembali koleksi setelah mengubah preset atau subtype. Mengosongkan perilaku preset juga dapat menghapus operasi visibilitas atau inisialisasi yang dibutuhkan preset. Contoh sengaja menggunakan bentuk yang terlihat dan mengganti perilaku; mereka tidak membangun kembali implementasi setiap preset.

## **Kompatibilitas Format**

Pohon perilaku yang dipertahankan tidak menjamin pemutaran identik di setiap penampil atau render ekspor. Periksa data yang disimpan dan output yang di‑render secara terpisah.

| Format atau output | Apa yang harus diverifikasi |
| --- | --- |
| PPTX | Gunakan sebagai format utama untuk contoh ini. Buka kembali untuk memverifikasi pohon perilaku yang dapat diedit, lalu periksa pemutaran di versi PowerPoint yang ditargetkan. |
| PPT | Representasi biner legacy dapat berbeda dari PPTX. Uji siklus simpan‑dan‑buka terpisah serta pemutaran; jangan menyimpulkan dukungan untuk setiap kombinasi kustom hanya dari output PPTX yang berhasil. |
| PDF, PNG, JPEG, dan gambar slide statis lainnya | Berisi representasi slide statis, bukan timeline perilaku yang dapat diputar atau frame animasi akhir yang dijamin. |
| [HTML5](/slides/id/cpp/export-to-html5/) | Dapat memutar animasi yang didukung ketika animasi bentuk diaktifkan dalam opsi ekspor. Uji kombinasi kustom di peramban. |
| [Animated GIF](/slides/id/cpp/convert-powerpoint-to-animated-gif/) | Menyimpan frame yang di‑render, bukan perilaku yang dapat diedit atau interaksi berbasis klik. Periksa gerakan yang sebenarnya di‑render. |
| [Video](/slides/id/cpp/convert-powerpoint-to-video/) | Merender frame animasi dan mengenkodenya sebagai video. Dukungan terbatas pada [animasi dan efek yang didukung](/slides/id/cpp/convert-powerpoint-to-video/#supported-animations-and-effects); perintah dan acara interaktif tidak menjadi timeline yang dapat diedit. |

## **FAQ**

**Mengapa efek saya berisi perilaku sebelum saya menambahkan apa pun?**

Membuat efek yang telah ditentukan dapat menciptakan operasi dasarnya. Periksa mereka sebelum memutuskan memperluas preset atau mengganti perilakunya.

**Apakah memindahkan perilaku ke awal membuatnya diputar pertama?**

Tidak selalu. Urutan koleksi bukan pengganti waktu. Periksa penundaan, durasi, dan interaksi antara operasi pada properti yang sama.

**Mengapa perintah end tidak memiliki titik?**

Itu menandai akhir jalur dan tidak memerlukan koordinat. Periksa array titik null saat memeriksa jalur yang dibaca dari berkas.

**Apakah perjalanan bolak‑balik yang berhasil cukup untuk mengonfirmasi pemutaran?**

Tidak. Membuka kembali mengonfirmasi pelestarian properti yang Anda periksa. Uji pemutar slideshow atau ekspor animasi secara terpisah untuk memastikan perilaku visualnya.