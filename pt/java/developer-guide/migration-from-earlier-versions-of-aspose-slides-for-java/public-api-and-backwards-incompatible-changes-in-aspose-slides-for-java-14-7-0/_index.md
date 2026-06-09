---
title: API pública e alterações incompatíveis com versões anteriores no Aspose.Slides para Java 14.7.0
linktitle: Aspose.Slides para Java 14.7.0
type: docs
weight: 60
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legado
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Revise as atualizações da API pública e as mudanças incompatíveis no Aspose.Slides para Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todas as classes, métodos, propriedades adicionados e assim por diante, quaisquer novas restrições e outras alterações introduzidas na API do Aspose.Slides for Java 14.7.0.

{{% /alert %}} 
## **Alterações da API Pública**
### **Construtores de alguns subtipos de TransitionValueBase foram removidos e TransitionValueFactory foi removido**
Os construtores de alguns subtipos de TransitionValueBase (e especificamente CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) são inúteis na API pública e, portanto, foram removidos. A classe relacionada TransitionValueFactory e sua interface ITransitionValueFactory foram removidas pelo mesmo motivo.
### **Elemento SoundAction foi removido da enumeração com.aspose.slides.TransitionType**
O elemento SoundAction estava incorreto e não era usado. As configurações de som são definidas pelas propriedades SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Classe FlyThroughTransition e interface IFlyThroughTransition foram adicionadas**
A classe com.aspose.slides.FlyThroughTransition (e sua interface com.aspose.slides.IFlyThroughTransition) refere‑se ao tipo de transição Flythrough que foi suportado nesta versão.
### **Classe GlitterTransition, interface IGlitterTransition e enumeração TransitionPattern foram adicionadas**
A classe com.aspose.slides.GlitterTransition (e sua interface com.aspose.slides.IGlitterTransition) refere‑se ao tipo de transição Glitter que foi suportado nesta versão. A enumeração com.aspose.slides.TransitionPattern é usada nesta classe e especifica um padrão geométrico que se repete para preencher uma área maior.
### **Classe LeftRightDirectionTransition, interface ILeftRightDirectionTransition e enumeração TransitionLeftRightDirectionType foram adicionadas**
A classe com.aspose.slides.LeftRightDirectionTransition (e sua interface com.aspose.slides.ILeftRightDirectionTransition) refere‑se aos tipos de transição Switch, Flip, Ferris, Gallery, Conveyor que foram suportados nesta versão. A enumeração com.aspose.slides.TransitionLeftRightDirectionType é usada nesta classe e especifica uma direção restrita aos valores left e right.
### **Novos elementos foram adicionados à enumeração com.aspose.slides.TransitionType**
A enumeração com.aspose.slides.TransitionType foi estendida com novos elementos. Novos elementos relacionados às transições do PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. Novos elementos relacionados às transições do PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Classe RevealTransition e interface IRevealTransition foram adicionadas**
A classe com.aspose.slides.RevealTransition (e sua interface com.aspose.slides.IRevealTransition) refere‑se ao tipo de transição Reveal que foi suportado nesta versão.
A classe RippleTransition, a interface IRippleTransition e a enumeração TransitionCornerAndCenterDirectionType foram adicionadas. A classe com.aspose.slides.RippleTransition (e sua interface com.aspose.slides.IRippleTransition) refere‑se ao tipo de transição Ripple que foi suportado nesta versão. A enumeração com.aspose.slides.TransitionCornerAndCenterDirectionType é usada nesta classe e especifica uma direção restrita aos cantos e ao centro.
### **Classe ShredTransition, interface IShredTransition e enumeração TransitionShredPattern foram adicionadas**
A classe com.aspose.slides.ShredTransition (e sua interface com.aspose.slides.IShredTransition) refere‑se ao tipo de transição Shred que foi suportado nesta versão. A enumeração com.aspose.slides.TransitionShredPattern é usada nesta classe e especifica uma forma geométrica que se repete para preencher uma área maior.