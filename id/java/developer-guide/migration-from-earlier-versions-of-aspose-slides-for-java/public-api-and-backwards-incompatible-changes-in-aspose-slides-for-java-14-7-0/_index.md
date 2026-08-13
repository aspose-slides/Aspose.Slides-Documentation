---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk Java 14.7.0
linktitle: Aspose.Slides untuk Java 14.7.0
type: docs
weight: 60
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- migrasi
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="info" %}} 

Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) serta batasan baru dan perubahan lain yang diperkenalkan dengan API Aspose.Slides for Java 14.7.0.

{{% /alert %}} 
## **Perubahan API Publik**
### **Konstruktor beberapa subtipe TransitionValueBase telah dihapus dan TransitionValueFactory juga dihapus**
Konstruktor beberapa subtipe TransitionValueBase (khususnya CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) tidak berguna dalam API publik dan oleh karena itu telah dihapus. Kelas terkait TransitionValueFactory dan antarmukanya ITransitionValueFactory telah dihapus dengan alasan yang sama.
### **Elemen SoundAction telah dihapus dari enumerasi com.aspose.slides.TransitionType**
Elemen SoundAction tidak tepat dan tidak digunakan. Pengaturan suara didefinisikan oleh properti SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Kelas FlyThroughTransition dan antarmuka IFlyThroughTransition telah ditambahkan**
Kelas com.aspose.slides.FlyThroughTransition (dan antarmukanya com.aspose.slides.IFlyThroughTransition) terkait dengan tipe transisi Flythrough yang telah didukung dalam rilis ini.
### **Kelas GlitterTransition, antarmuka IGlitterTransition, dan enumerasi TransitionPattern telah ditambahkan**
Kelas com.aspose.slides.GlitterTransition (dan antarmukanya com.aspose.slides.IGlitterTransition) terkait dengan tipe transisi Glitter yang telah didukung dalam rilis ini. Enumerasi com.aspose.slides.TransitionPattern digunakan dalam kelas ini dan menentukan pola geometris yang disusun bersama untuk mengisi area yang lebih besar.
### **Kelas LeftRightDirectionTransition, antarmuka ILeftRightDirectionTransition, dan enumerasi TransitionLeftRightDirectionType telah ditambahkan**
Kelas com.aspose.slides.LeftRightDirectionTransition (dan antarmukanya com.aspose.slides.ILeftRightDirectionTransition) terkait dengan tipe transisi Switch, Flip, Ferris, Gallery, Conveyor yang telah didukung dalam rilis ini. Enumerasi com.aspose.slides.TransitionLeftRightDirectionType digunakan dalam kelas ini dan menentukan arah yang dibatasi pada nilai left dan right.
### **Elemen baru telah ditambahkan ke dalam enumerasi com.aspose.slides.TransitionType**
Enumerasi com.aspose.slides.TransitionType telah diperluas dengan elemen baru. Elemen baru terkait transisi PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Elemen baru terkait transisi PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Kelas RevealTransition dan antarmuka IRevealTransition telah ditambahkan**
Kelas com.aspose.slides.RevealTransition (dan antarmukanya com.aspose.slides.IRevealTransition) terkait dengan tipe transisi Reveal yang telah didukung dalam rilis ini. Kelas RippleTransition, antarmuka IRippleTransition, dan enumerasi TransitionCornerAndCenterDirectionType telah ditambahkan. Kelas com.aspose.slides.RippleTransition (dan antarmukanya com.aspose.slides.IRippleTransition) terkait dengan tipe transisi Ripple yang telah didukung dalam rilis ini. Enumerasi com.aspose.slides.TransitionCornerAndCenterDirectionType digunakan dalam kelas ini dan menentukan arah yang dibatasi pada sudut dan tengah.
### **Kelas ShredTransition, antarmuka IShredTransition, dan enumerasi TransitionShredPattern telah ditambahkan**
Kelas com.aspose.slides.ShredTransition (dan antarmukanya com.aspose.slides.IShredTransition) terkait dengan tipe transisi Shred yang telah didukung dalam rilis ini. Enumerasi com.aspose.slides.TransitionShredPattern digunakan dalam kelas ini dan menentukan bentuk geometris yang disusun bersama untuk mengisi area yang lebih besar.