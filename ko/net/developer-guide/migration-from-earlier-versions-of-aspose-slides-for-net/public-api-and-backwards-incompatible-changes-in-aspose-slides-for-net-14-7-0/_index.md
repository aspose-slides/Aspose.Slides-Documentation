---
title: Aspose.Slides for .NET 14.7.0에서 공개 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 14.7.0
type: docs
weight: 90
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- 마이그레이션
- 레거시 코드
- 모던 코드
- 레거시 접근 방식
- 현대 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET의 공개 API 업데이트 및 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하세요."
---
{{% alert color="primary" %}} 

이 페이지에서는 Aspose.Slides for .NET 14.7.0 API와 함께 도입된 모든 [added](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) 또는 [removed](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) 클래스, 메서드, 속성 등을 나열하고 기타 변경 사항을 보여줍니다.

{{% /alert %}} 
## **공개 API 변경 사항**
### **제거된 생성자 및 요소**
#### **일부 TransitionValueBase 하위 유형 생성자 및 TransitionValueFactory 제거**
일부 TransitionValueBase 하위 유형(구체적으로 CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition)의 생성자는 공개 API에서 쓸모가 없어 제거되었습니다.  

같은 이유로 관련 클래스 TransitionValueFactory와 인터페이스 ITransitionValueFactory도 제거되었습니다.  
#### **Aspose.Slides.SlideShow.TransitionType 열거형에서 SoundAction 요소 제거**
SoundAction 요소는 잘못되었으며 사용되지 않았습니다. 사운드 설정은 SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName 속성을 통해 정의됩니다.  
### **추가된 클래스 및 인터페이스**
#### **FlyThroughTransition 클래스 및 IFlyThroughTransition 인터페이스 추가**
Aspose.Slides.SlideShow.FlyThroughTransition 클래스(및 인터페이스 Aspose.Slides.SlideShow.IFlyThroughTransition)는 이번 릴리스에서 지원되는 Flythrough 전환 유형과 관련됩니다.  
#### **GlitterTransition 클래스, IGlitterTransition 인터페이스 및 TransitionPattern 열거형 추가**
Aspose.Slides.SlideShow.GlitterTransition 클래스(및 인터페이스 Aspose.Slides.SlideShow.IGlitterTransition)는 이번 릴리스에서 지원되는 Glitter 전환 유형과 관련됩니다.  

Aspose.Slides.SlideShow.TransitionPattern 열거형은 이 클래스에서 사용되며, 더 큰 영역을 채우기 위해 타일 형태로 결합되는 기하학적 패턴을 지정합니다.  
#### **LeftRightDirectionTransition 클래스, ILeftRightDirectionTransition 인터페이스 및 TransitionLeftRightDirectionType 열거형 추가**
Aspose.Slides.SlideShow.LeftRightDirectionTransition 클래스(및 인터페이스 Aspose.Slides.SlideShow.ILeftRightDirectionTransition)는 Conveyor, Ferris, Flip, Gallery 및 Switch 전환 유형과 관련됩니다. 모두 이번 릴리스에서 지원됩니다.  

Aspose.Slides.SlideShow.TransitionLeftRightDirectionType 열거형은 이 클래스에서 사용되며, left와 right 값으로 제한된 방향을 지정합니다.  
#### **Aspose.Slides.SlideShow.TransitionType 열거형에 새로운 요소 추가**
Aspose.Slides.SlideShow.TransitionType 열거형에 새로운 요소가 추가되었습니다.  

- PowerPoint 2010 전환과 관련된 새로운 요소: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.  
- PowerPoint 2013 전환과 관련된 새로운 요소: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.  
#### **RevealTransition 클래스 및 IRevealTransition 인터페이스 추가**
Aspose.Slides.SlideShow.RevealTransition 클래스(및 인터페이스 Aspose.Slides.SlideShow.IRevealTransition)는 이번 릴리스에서 지원되는 Reveal 전환 유형과 관련됩니다.  
#### **RippleTransition 클래스, IRippleTransition 인터페이스 및 TransitionCornerAndCenterDirectionType 열거형 추가**
Aspose.Slides.SlideShow.RippleTransition 클래스(및 인터페이스 Aspose.Slides.SlideShow.IRippleTransition)는 이번 릴리스에서 지원되는 Ripple 전환 유형과 관련됩니다.  

Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType 열거형은 이 클래스에서 사용되며, 모서리와 중앙으로 제한된 방향을 지정합니다.