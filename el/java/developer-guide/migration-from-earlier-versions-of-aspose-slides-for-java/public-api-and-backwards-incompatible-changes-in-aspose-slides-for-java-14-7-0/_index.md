---
title: Δημόσιο API και Αλλαγές που Ασυμβατοποιούνται με Παλαιότερες Εκδόσεις στο Aspose.Slides για Java 14.7.0
linktitle: Aspose.Slides για Java 14.7.0
type: docs
weight: 60
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- μεταφορά
- παραδοσιακός κώδικας
- σύγχρονος κώδικας
- παραδοσιακή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Εξετάστε τις ενημερώσεις του δημόσιου API και τις αλλαγές που προκαλούν σπάσιμο στο Aspose.Slides για Java, ώστε να μεταβείτε ομαλά στις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 

Αυτή η σελίδα παραθέτει όλες τις κλάσεις, μεθόδους, ιδιότητες κλπ. που προστέθηκαν, τυχόν νέους περιορισμούς και άλλα αλλαγμένα στοιχεία που εισήχθησαν με το Aspose.Slides for Java 14.7.0 API.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
### **Οι κατασκευαστές ορισμένων υποτύπων του TransitionValueBase αφαιρέθηκαν και το TransitionValueFactory αφαιρέθηκε**
Οι κατασκευαστές ορισμένων υποτύπων του TransitionValueBase (και συγκεκριμένα CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) δεν είναι χρήσιμοι στο δημόσιο API και επομένως αφαιρέθηκαν. Η σχετική κλάση TransitionValueFactory και η διεπαφή της ITransitionValueFactory αφαιρέθηκαν για τον ίδιο λόγο.
### **Το στοιχείο SoundAction αφαιρέθηκε από την απαρίθμηση com.aspose.slides.TransitionType**
Το στοιχείο SoundAction ήταν λανθασμένο και δεν χρησιμοποιείται. Οι ρυθμίσεις ήχου ορίζονται από τις ιδιότητες SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Προστέθηκε η κλάση FlyThroughTransition και η διεπαφή IFlyThroughTransition**
Η κλάση com.aspose.slides.FlyThroughTransition (και η διεπαφή της com.aspose.slides.IFlyThroughTransition) σχετίζονται με τον τύπο μετάβασης Flythrough που υποστηρίζεται σε αυτήν την έκδοση.
### **Προστέθηκαν η κλάση GlitterTransition, η διεπαφή IGlitterTransition και η απαρίθμηση TransitionPattern**
Η κλάση com.aspose.slides.GlitterTransition (και η διεπαφή της com.aspose.slides.IGlitterTransition) σχετίζονται με τον τύπο μετάβασης Glitter που υποστηρίζεται σε αυτήν την έκδοση. Η απαρίθμηση com.aspose.slides.TransitionPattern χρησιμοποιείται σε αυτήν την κλάση και καθορίζει ένα γεωμετρικό μοτίβο που ενώνει πλακίδια για να καλύψει μεγαλύτερη επιφάνεια.
### **Προστέθηκαν η κλάση LeftRightDirectionTransition, η διεπαφή ILeftRightDirectionTransition και η απαρίθμηση TransitionLeftRightDirectionType**
Η κλάση com.aspose.slides.LeftRightDirectionTransition (και η διεπαφή της com.aspose.slides.ILeftRightDirectionTransition) σχετίζονται με τους τύπους μετάβασης Switch, Flip, Ferris, Gallery, Conveyor που υποστηρίζονται σε αυτήν την έκδοση. Η απαρίθμηση com.aspose.slides.TransitionLeftRightDirectionType χρησιμοποιείται στην κλάση αυτή και καθορίζει μια κατεύθυνση περιορισμένη στις τιμές left και right.
### **Προστέθηκαν νέα στοιχεία στην απαρίθμηση com.aspose.slides.TransitionType**
Η απαρίθμηση com.aspose.slides.TransitionType επεκτάθηκε με νέα στοιχεία. 
Νέα στοιχεία που σχετίζονται με τις μεταβάσεις PowerPoint 2010: Vortex, Switch, Flip, Ripple, Honeycomb, Cube, Box, Rotate, Orbit, Doors, Window, Ferris, Gallery, Conveyor, Pan, Glitter, Warp, Flythrough, Flash, Shred, Reveal, WheelReverse. 
Νέα στοιχεία που σχετίζονται με τις μεταβάσεις PowerPoint 2013: FallOver, Drape, Curtains, Wind, Prestige, Fracture, Crush, PeelOff, PageCurlDouble, PageCurlSingle, Airplane, Origami.
### **Προστέθηκαν η κλάση RevealTransition και η διεπαφή IRevealTransition**
Η κλάση com.aspose.slides.RevealTransition (και η διεπαφή της com.aspose.slides.IRevealTransition) σχετίζονται με τον τύπο μετάβασης Reveal που υποστηρίζεται σε αυτήν την έκδοση. 
Προστέθηκαν η κλάση RippleTransition, η διεπαφή IRippleTransition και η απαρίθμηση TransitionCornerAndCenterDirectionType
Η κλάση com.aspose.slides.RippleTransition (και η διεπαφή της com.aspose.slides.IRippleTransition) σχετίζεται με τον τύπο μετάβασης Ripple που υποστηρίζεται σε αυτήν την έκδοση. Η απαρίθμηση com.aspose.slides.TransitionCornerAndCenterDirectionType χρησιμοποιείται στην κλάση αυτή και καθορίζει μια κατεύθυνση περιορισμένη στις γωνίες και το κέντρο.
### **Προστέθηκαν η κλάση ShredTransition, η διεπαφή IShredTransition και η απαρίθμηση TransitionShredPattern**
Η κλάση com.aspose.slides.ShredTransition (και η διεπαφή της com.aspose.slides.IShredTransition) σχετίζεται με τον τύπο μετάβασης Shred που υποστηρίζεται σε αυτήν την έκδοση. Η απαρίθμηση com.aspose.slides.TransitionShredPattern χρησιμοποιείται στην κλάση αυτή και καθορίζει ένα γεωμετρικό σχήμα που ενώνει πλακίδια για να καλύψει μεγαλύτερη επιφάνεια.