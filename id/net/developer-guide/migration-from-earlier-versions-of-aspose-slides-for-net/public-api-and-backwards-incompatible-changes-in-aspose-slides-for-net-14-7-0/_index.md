---
title: Perubahan API Publik dan Tidak Kompatibel Mundur di Aspose.Slides untuk .NET 14.7.0
linktitle: Aspose.Slides untuk .NET 14.7.0
type: docs
weight: 90
url: /id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- migrasi
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang memutuskan kompatibilitas di Aspose.Slides untuk .NET agar dapat memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan mulus."
---
{{% alert color="info" %}} 
Halaman ini menampilkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) atau [dihapus](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/), serta perubahan lain yang diperkenalkan dengan API Aspose.Slides for .NET 14.7.0.
{{% /alert %}} 
## **Public API Changes**
### **Removed Constructors and Elements**
#### **Removed Some TransitionValueBase Subtype Constructors and TransitionValueFactory**
Konstruktor beberapa subtipe TransitionValueBase (khususnya CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) tidak berguna dalam API publik sehingga telah dihapus. 

Kelas terkait TransitionValueFactory dan interfacenya ITransitionValueFactory juga telah dihapus dengan alasan yang sama.
#### **Removed the SoundAction Element from the Aspose.Slides.SlideShow.TransitionType Enumeration**
Elemen SoundAction tidak benar dan tidak digunakan. Pengaturan suara didefinisikan oleh properti SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Added Classes and Interfaces**
#### **Added the FlyThroughTransition Class and IFlyThroughTransition Interface**
Kelas Aspose.Slides.SlideShow.FlyThroughTransition (dan interfacenya Aspose.Slides.SlideShow.IFlyThroughTransition) terkait dengan tipe transisi Flythrough yang didukung mulai rilis ini.
#### **Added the GlitterTransition Class, IGlitterTransition Interface and TransitionPattern Enumeration**
Kelas Aspose.Slides.SlideShow.GlitterTransition (dan interfacenya Aspose.Slides.SlideShow.IGlitterTransition) terkait dengan tipe transisi Glitter yang didukung mulai rilis ini.

Enumerasi Aspose.Slides.SlideShow.TransitionPattern digunakan dalam kelas ini dan menentukan pola geometris yang menyusun bersama untuk mengisi area yang lebih besar.
#### **Added the LeftRightDirectionTransition Class, ILeftRightDirectionTransition Interface and TransitionLeftRightDirectionType Enumeration**
Kelas Aspose.Slides.SlideShow.LeftRightDirectionTransition (dan interfacenya Aspose.Slides.SlideShow.ILeftRightDirectionTransition) terkait dengan tipe transisi Conveyor, Ferris, Flip, Gallery, dan Switch. Semua didukung mulai rilis ini.

Enumerasi Aspose.Slides.SlideShow.TransitionLeftRightDirectionType digunakan dalam kelas ini dan menentukan arah, terbatas pada nilai left dan right.
#### **Added New Elements to the Aspose.Slides.SlideShow.TransitionType Enumeration**
Enumerasi Aspose.Slides.SlideShow.TransitionType telah diperluas dengan elemen‑elemen baru.

- Elemen baru yang terkait dengan transisi PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Elemen baru yang terkait dengan transisi PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Added the RevealTransition Class and IRevealTransition Interface**
Kelas Aspose.Slides.SlideShow.RevealTransition (dan interfacenya Aspose.Slides.SlideShow.IRevealTransition) terkait dengan tipe transisi Reveal yang didukung mulai rilis ini.
#### **Added the RippleTransition Class, IRippleTransition Interface and TransitionCornerAndCenterDirectionType Enumeration**
Kelas Aspose.Slides.SlideShow.RippleTransition (dan interfacenya Aspose.Slides.SlideShow.IRippleTransition) terkait dengan tipe transisi Ripple yang didukung mulai rilis ini.

Enumerasi Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType digunakan dalam kelas ini dan menentukan arah, terbatas pada sudut‑sudut dan tengah.