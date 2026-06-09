---
title: Aspose.Slides for .NET 14.7.0'da Genel API ve Geriye Uyumsuz Değişiklikler
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
description: "Aspose.Slides for .NET'teki genel API güncellemeleri ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizin sorunsuz bir şekilde geçişini sağlayın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for .NET 14.7.0 API'si ile tanıtılan [eklenen](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) veya [kaldırılan](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) sınıflar, metodlar, özellikler vb. ve diğer değişiklikleri listeler.

{{% /alert %}} 
## **Genel API Değişiklikleri**
### **Kaldırılan Yapılandırıcılar ve Elemanlar**
#### **Bazı TransitionValueBase Alt Türü Yapılandırıcıları ve TransitionValueFactory Kaldırıldı**
Bazı TransitionValueBase alt türlerinin (özellikle CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) yapılandırıcıları genel API'de kullanılmaz ve bu yüzden kaldırılmıştır.  

Aynı nedenle ilgili TransitionValueFactory sınıfı ve ITransitionValueFactory arayüzü de kaldırılmıştır.  
#### **Aspose.Slides.SlideShow.TransitionType Enum'undan SoundAction Elemanı Kaldırıldı**
SoundAction öğesi yanlıştı ve kullanılmıyordu. Ses ayarları SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName özellikleriyle tanımlanır.  
### **Eklenen Sınıflar ve Arabirimler**
#### **FlyThroughTransition Sınıfı ve IFlyThroughTransition Arabirimi Eklendi**
Aspose.Slides.SlideShow.FlyThroughTransition sınıfı (ve onun Arabirimi Aspose.Slides.SlideShow.IFlyThroughTransition) bu sürümden itibaren desteklenen Flythrough geçiş türüyle ilgilidir.  
#### **GlitterTransition Sınıfı, IGlitterTransition Arabirimi ve TransitionPattern Enum'ı Eklendi**
Aspose.Slides.SlideShow.GlitterTransition sınıfı (ve onun Arabirimi Aspose.Slides.SlideShow.IGlitterTransition) bu sürümden itibaren desteklenen Glitter geçiş türüyle ilgilidir.  

Aspose.Slides.SlideShow.TransitionPattern enum'ı bu sınıfta kullanılır ve daha büyük bir alanı doldurmak için bir araya gelen geometrik bir deseni tanımlar.  
#### **LeftRightDirectionTransition Sınıfı, ILeftRightDirectionTransition Arabirimi ve TransitionLeftRightDirectionType Enum'ı Eklendi**
Aspose.Slides.SlideShow.LeftRightDirectionTransition sınıfı (ve onun Arabirimi Aspose.Slides.SlideShow.ILeftRightDirectionTransition) Conveyor, Ferris, Flip, Gallery ve Switch geçiş türleriyle ilgilidir. Hepsi bu sürümden itibaren desteklenir.  

Aspose.Slides.SlideShow.TransitionLeftRightDirectionType enum'ı bu sınıfta kullanılır ve yalnızca left ve right değerlerine izin veren bir yön belirtir.  
#### **Aspose.Slides.SlideShow.TransitionType Enum'ına Yeni Elemanlar Eklendi**
Aspose.Slides.SlideShow.TransitionType enum'ı yeni elemanlarla genişletildi.  

- PowerPoint 2010 geçişleriyle ilgili yeni elemanlar: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.  
- PowerPoint 2013 yeni geçişleriyle ilgili yeni elemanlar: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.  
#### **RevealTransition Sınıfı ve IRevealTransition Arabirimi Eklendi**
Aspose.Slides.SlideShow.RevealTransition sınıfı (ve onun Arabirimi Aspose.Slides.SlideShow.IRevealTransition) bu sürümden itibaren desteklenen Reveal geçiş türüyle ilgilidir.  
#### **RippleTransition Sınıfı, IRippleTransition Arabirimi ve TransitionCornerAndCenterDirectionType Enum'ı Eklendi**
Aspose.Slides.SlideShow.RippleTransition sınıfı (ve onun Arabirimi Aspose.Slides.SlideShow.IRippleTransition) bu sürümden itibaren desteklenen Ripple geçiş türüyle ilgilidir.  

Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType enum'ı bu sınıfta kullanılır ve köşeler ile merkeze sınırlı bir yön belirtir.