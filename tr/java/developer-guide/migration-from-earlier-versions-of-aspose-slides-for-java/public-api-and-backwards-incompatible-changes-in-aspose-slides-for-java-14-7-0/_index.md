---
title: Aspose.Slides for Java 14.7.0'da Genel API ve Geriye Dönük Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 14.7.0
type: docs
weight: 60
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for Java 14.7.0 API'siyle tanıtılan tüm [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) sınıfları, metodları, özellikleri ve benzerlerini, yeni kısıtlamaları ve diğer değişiklikleri listeler.

{{% /alert %}} 
## **Genel API Değişiklikleri**
### **Bazı TransitionValueBase alt türlerinin kurucuları kaldırıldı ve TransitionValueFactory kaldırıldı**
Bazı TransitionValueBase alt türlerinin (özellikle CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) kurucuları genel API'de kullanılmaz ve bu yüzden kaldırıldı. İlgili sınıf TransitionValueFactory ve arayüzü ITransitionValueFactory aynı nedenle kaldırıldı.
### **SoundAction öğesi com.aspose.slides.TransitionType numaralandırmasından kaldırıldı**
SoundAction öğesi yanlıştı ve kullanılmıyordu. Ses ayarları SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName özellikleriyle tanımlanır.
### **FlyThroughTransition sınıfı ve IFlyThroughTransition arayüzü eklendi**
com.aspose.slides.FlyThroughTransition sınıfı (ve arayüzü com.aspose.slides.IFlyThroughTransition), bu sürümde desteklenen Flythrough geçiş türüyle ilişkilidir.
### **GlitterTransition sınıfı, IGlitterTransition arayüzü ve TransitionPattern numaralandırması eklendi**
com.aspose.slides.GlitterTransition sınıfı (ve arayüzü com.aspose.slides.IGlitterTransition), bu sürümde desteklenen Glitter geçiş türüyle ilişkilidir. com.aspose.slides.TransitionPattern numaralandırması bu sınıfta kullanılır ve daha büyük bir alanı doldurmak için yan yana döşenen geometrik bir deseni belirtir.
### **LeftRightDirectionTransition sınıfı, ILeftRightDirectionTransition arayüzü ve TransitionLeftRightDirectionType numaralandırması eklendi**
com.aspose.slides.LeftRightDirectionTransition sınıfı (ve arayüzü com.aspose.slides.ILeftRightDirectionTransition), bu sürümde desteklenen Switch, Flip, Ferris, Gallery, Conveyor geçiş türleriyle ilişkilidir. com.aspose.slides.TransitionLeftRightDirectionType numaralandırması bu sınıfta kullanılır ve yönü sadece left ve right değerleriyle sınırlı tutar.
### **com.aspose.slides.TransitionType numaralandırmasına yeni öğeler eklendi**
com.aspose.slides.TransitionType numaralandırması yeni öğelerle genişletildi. PowerPoint 2010 geçişlerine ilişkin yeni öğeler: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. PowerPoint 2013 geçişlerine ilişkin yeni öğeler: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **RevealTransition sınıfı ve IRevealTransition arayüzü eklendi**
com.aspose.slides.RevealTransition sınıfı (ve arayüzü com.aspose.slides.IRevealTransition), bu sürümde desteklenen Reveal geçiş türüyle ilişkilidir.
RippleTransition sınıfı, IRippleTransition arayüzü ve TransitionCornerAndCenterDirectionType numaralandırması eklendi. com.aspose.slides.RippleTransition sınıfı (ve arayüzü com.aspose.slides.IRippleTransition), bu sürümde desteklenen Ripple geçiş türüyle ilişkilidir. com.aspose.slides.TransitionCornerAndCenterDirectionType numaralandırması bu sınıfta kullanılır ve yönü sadece köşeler ve merkezle sınırlı tutar.
### **ShredTransition sınıfı, IShredTransition arayüzü ve TransitionShredPattern numaralandırması eklendi**
com.aspose.slides.ShredTransition sınıfı (ve arayüzü com.aspose.slides.IShredTransition), bu sürümde desteklenen Shred geçiş türüyle ilişkilidir. com.aspose.slides.TransitionShredPattern numaralandırması bu sınıfta kullanılır ve daha büyük bir alanı doldurmak için yan yana döşenen geometrik bir şekli belirtir.