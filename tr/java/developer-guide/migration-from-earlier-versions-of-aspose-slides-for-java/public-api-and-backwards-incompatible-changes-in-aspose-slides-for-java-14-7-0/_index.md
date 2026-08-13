---
title: "Aspose.Slides for Java 14.7.0'da Genel API ve Geriye Uyumsuz Değişiklikler"
linktitle: "Aspose.Slides for Java 14.7.0"
type: docs
weight: 60
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- "göç"
- "eski kod"
- "modern kod"
- "eski yaklaşım"
- "modern yaklaşım"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java'da genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 

Bu sayfa, Aspose.Slides for Java 14.7.0 API'si ile tanıtılan yeni kısıtlamalar ve diğer değişiklikler dahil olmak üzere eklenen tüm [added](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) sınıfları, yöntemleri, özellikleri ve benzerlerini listeler.

{{% /alert %}} 
## **Public API Değişiklikleri**
### **Constructors of the some TransitionValueBase subtypes have been removed and TransitionValueFactory has been removed**
Bazı TransitionValueBase alt türlerinin (özellikle CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) yapıcıları genel API'de işe yaramaz ve bu nedenle kaldırılmıştır. İlgili sınıf TransitionValueFactory ve arayüzü ITransitionValueFactory aynı nedenle kaldırılmıştır.
### **Element SoundAction has been removed from com.aspose.slides.TransitionType enumeration**
SoundAction öğesi hatalıydı ve kullanılmıyordu. Ses ayarları SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName özellikleriyle tanımlanır.
### **FlyThroughTransition class and IFlyThroughTransition interface have been added**
com.aspose.slides.FlyThroughTransition sınıfı (ve arayüzü com.aspose.slides.IFlyThroughTransition) bu sürümde desteklenen Flythrough geçiş türüyle ilgilidir.
### **GlitterTransition class, IGlitterTransition interface and TransitionPattern enumeration have been added**
com.aspose.slides.GlitterTransition sınıfı (ve arayüzü com.aspose.slides.IGlitterTransition) bu sürümde desteklenen Glitter geçiş türüyle ilgilidir.
com.aspose.slides.TransitionPattern enumerasyonu bu sınıfta kullanılır ve daha büyük bir alanı doldurmak için bir araya gelen geometrik bir deseni belirtir.
### **LeftRightDirectionTransition class, ILeftRightDirectionTransition interface and TransitionLeftRightDirectionType enumeration have been added**
com.aspose.slides.LeftRightDirectionTransition sınıfı (ve arayüzü com.aspose.slides.ILeftRightDirectionTransition) bu sürümde desteklenen Switch, Flip, Ferris, Gallery, Conveyor geçiş türleriyle ilgilidir.
com.aspose.slides.TransitionLeftRightDirectionType enumerasyonu bu sınıfta kullanılır ve yönün sadece left ve right değerleriyle sınırlı olduğunu belirtir.
### **New elements have been added into com.aspose.slides.TransitionType enumeration**
com.aspose.slides.TransitionType enumerasyonu yeni öğelerle genişletilmiştir.
PowerPoint 2010 yeni geçişleriyle ilgili yeni öğeler: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse.
PowerPoint 2013 yeni geçişleriyle ilgili yeni öğeler: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **RevealTransition class and IRevealTransition interface have been added**
com.aspose.slides.RevealTransition sınıfı (ve arayüzü com.aspose.slides.IRevealTransition) bu sürümde desteklenen Reveal geçiş türüyle ilgilidir.
RippleTransition sınıfı, IRippleTransition arayüzü ve TransitionCornerAndCenterDirectionType enumerasyonu eklendi
com.aspose.slides.RippleTransition sınıfı (ve arayüzü com.aspose.slides.IRippleTransition) bu sürümde desteklenen Ripple geçiş türüyle ilgilidir.
com.aspose.slides.TransitionCornerAndCenterDirectionType enumerasyonu bu sınıfta kullanılır ve yönün köşeler ve merkezle sınırlı olduğunu belirtir.
### **ShredTransition class, IShredTransition interface and TransitionShredPattern enumeration have been added**
com.aspose.slides.ShredTransition sınıfı (ve arayüzü com.aspose.slides.IShredTransition) bu sürümde desteklenen Shred geçiş türüyle ilgilidir.
com.aspose.slides.TransitionShredPattern enumerasyonu bu sınıfta kullanılır ve daha büyük bir alanı doldurmak için bir araya gelen geometrik bir şekli belirtir.