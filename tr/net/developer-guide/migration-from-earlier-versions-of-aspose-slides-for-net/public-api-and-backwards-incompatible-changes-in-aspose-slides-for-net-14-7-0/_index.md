---
title: Aspose.Slides for .NET 14.7.0'de Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for .NET 14.7.0
type: docs
weight: 90
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}}

Bu sayfa, Aspose.Slides for .NET 14.7.0 API'siyle tanıtılan eklenen [eklenen](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) veya [kaldırılan](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) sınıfları, metodları, özellikleri vb. ve diğer değişiklikleri listeler.

{{% /alert %}}
## **Genel API Değişiklikleri**
### **Kaldırılan Yapıcılar ve Öğeler**
#### **Bazı TransitionValueBase Alt Tip Yapıcıları ve TransitionValueFactory Kaldırıldı**
Bazı TransitionValueBase alt tiplerinin (özellikle CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) yapıcıları, genel API'de işe yaramaz ve bu yüzden kaldırıldı.  
Aynı sebeple ilgili TransitionValueFactory sınıfı ve ITransitionValueFactory arayüzü kaldırıldı.  
#### **Aspose.Slides.SlideShow.TransitionType Enümerasyonundan SoundAction Öğesi Kaldırıldı**
SoundAction öğesi hatalıydı ve kullanılmıyordu. Ses ayarları SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName özellikleriyle tanımlanır.  
### **Eklenen Sınıflar ve Arayüzler**
#### **FlyThroughTransition Sınıfı ve IFlyThroughTransition Arayüzü Eklendi**
Aspose.Slides.SlideShow.FlyThroughTransition sınıfı (ve Aspose.Slides.SlideShow.IFlyThroughTransition arayüzü), bu sürümden itibaren desteklenen Flythrough geçiş türüyle ilgilidir.  
#### **GlitterTransition Sınıfı, IGlitterTransition Arayüzü ve TransitionPattern Enümerasyonu Eklendi**
Aspose.Slides.SlideShow.GlitterTransition sınıfı (ve Aspose.Slides.SlideShow.IGlitterTransition arayüzü), bu sürümden itibaren desteklenen Glitter geçiş türüyle ilgilidir.  
Aspose.Slides.SlideShow.TransitionPattern enümerasyonu bu sınıfta kullanılır ve daha büyük bir alanı doldurmak için yan yana yerleştirilen geometrik bir deseni tanımlar.  
#### **LeftRightDirectionTransition Sınıfı, ILeftRightDirectionTransition Arayüzü ve TransitionLeftRightDirectionType Enümerasyonu Eklendi**
Aspose.Slides.SlideShow.LeftRightDirectionTransition sınıfı (ve Aspose.Slides.SlideShow.ILeftRightDirectionTransition arayüzü), Conveyor, Ferris, Flip, Gallery ve Switch geçiş türleriyle ilgilidir. Hepsi bu sürümden itibaren desteklenir.  
Aspose.Slides.SlideShow.TransitionLeftRightDirectionType enümerasyonu bu sınıfta kullanılır ve sadece left ve right değerleriyle sınırlı bir yön belirler.  
#### **Aspose.Slides.SlideShow.TransitionType Enümerasyonuna Yeni Öğeler Eklendi**
Aspose.Slides.SlideShow.TransitionType enümerasyonu yeni öğelerle genişletildi.  

- PowerPoint 2010 geçişleriyle ilgili yeni öğeler: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.  
- PowerPoint 2013 yeni geçişleriyle ilgili yeni öğeler: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.  

#### **RevealTransition Sınıfı ve IRevealTransition Arayüzü Eklendi**
Aspose.Slides.SlideShow.RevealTransition sınıfı (ve Aspose.Slides.SlideShow.IRevealTransition arayüzü), bu sürümden itibaren desteklenen Reveal geçiş türüyle ilgilidir.  
#### **RippleTransition Sınıfı, IRippleTransition Arayüzü ve TransitionCornerAndCenterDirectionType Enümerasyonu Eklendi**
Aspose.Slides.SlideShow.RippleTransition sınıfı (ve Aspose.Slides.SlideShow.IRippleTransition arayüzü), bu sürümden itibaren desteklenen Ripple geçiş türüyle ilgilidir.  
Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType enümerasyonu bu sınıfta kullanılır ve köşeler ve merkezle sınırlı bir yön belirtir.